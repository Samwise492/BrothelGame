using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using BrothelGame.Infrastructure.Core;
using BrothelGame.Windows;
using R3;
using ObservableCollections;

namespace BrothelGame.Infrastructure.Core
{
    public abstract class View : DisposableCollector
    {
        private readonly IViewFactory viewFactory;
        private readonly List<View> childViews = new();

        protected View(IViewFactory viewFactory)
        {
            this.viewFactory = viewFactory;
        }

        public virtual bool IsActive() => false;
        public abstract void SetActive(bool status);

        protected virtual void ReleaseViewModel()
        {
        }

        public virtual void ClearViewModel()
        {
            for (var i = 0; i < childViews.Count; i++)
            {
                childViews[i].ClearViewModel();
            }
        }
    }

    public abstract class View<THierarchy> : View where THierarchy : MonoBehaviour
    {
        public THierarchy Hierarchy { get; }

        protected View(THierarchy hierarchy, IViewFactory viewFactory) : base(viewFactory)
        {
            Hierarchy = hierarchy;
        }

        public override void SetActive(bool active)
        {
            Hierarchy.gameObject.SetActive(active);
        }

        public override bool IsActive()
        {
            return Hierarchy.gameObject.activeInHierarchy;
        }
    }

    public abstract class View<THierarchy, TViewModel> : View<THierarchy>
            where THierarchy : MonoBehaviour
            where TViewModel : class, IViewModel
    {
        private readonly List<IDisposable> bindDisposables = new();
        private readonly List<(Button button, UnityAction onClick)> bindButtonDisposables = new();
        private readonly List<(Slider slider, UnityAction<float> onChange)> bindSliderDisposables = new();
        private readonly List<(Toggle toggle, UnityAction<bool> onChange)> bindToggleDisposables = new();
        private readonly List<(TMP_InputField submit, UnityAction<string> onChange)> bindSubmitDisposables = new();
        private readonly List<(TMP_InputField submit, UnityAction<string> onChange)> bindValueChangedDisposables = new();
        private readonly List<(TMP_Dropdown, UnityAction<int> onChange)> bindDropDownDisposables = new();
        private readonly List<(ScrollRect.ScrollRectEvent, UnityAction<Vector2> onChange)> bindScroll = new();
        private readonly List<(Scrollbar.ScrollEvent, UnityAction<float> onChange)> bindScrollbar = new();

        protected TViewModel ViewModel { get; private set; }

        protected View(THierarchy hierarchy, IViewFactory viewFactory) : base(hierarchy, viewFactory)
        {
        }

        public void Initialize(TViewModel viewModel)
        {
            ClearViewModel();
            ViewModel = viewModel;
            UpdateViewModel(viewModel);
        }

        protected abstract void UpdateViewModel(TViewModel viewModel);

        protected override void ReleaseViewModel()
        {
            base.ReleaseViewModel();
            for (int i = 0; i < bindDisposables.Count; i++)
                bindDisposables[i].Dispose();

            bindDisposables.Clear();

            for (var index = 0; index < bindButtonDisposables.Count; index++)
            {
                (Button button, UnityAction onClick) = bindButtonDisposables[index];
                button.onClick.RemoveListener(onClick);
            }

            bindButtonDisposables.Clear();

            for (var index = 0; index < bindSliderDisposables.Count; index++)
            {
                (Slider slider, UnityAction<float> onChange) = bindSliderDisposables[index];
                slider.onValueChanged.RemoveListener(onChange);
            }

            bindSliderDisposables.Clear();

            for (var index = 0; index < bindToggleDisposables.Count; index++)
            {
                (Toggle toggle, UnityAction<bool> onChange) = bindToggleDisposables[index];
                toggle.onValueChanged.RemoveListener(onChange);
            }

            bindToggleDisposables.Clear();

            for (var index = 0; index < bindSubmitDisposables.Count; index++)
            {
                (TMP_InputField inputField, UnityAction<string> onChange) = bindSubmitDisposables[index];
                inputField.onSubmit.RemoveListener(onChange);
            }

            for (var index = 0; index < bindValueChangedDisposables.Count; index++)
            {
                (TMP_InputField inputField, UnityAction<string> onChange) = bindValueChangedDisposables[index];
                inputField.onValueChanged.RemoveListener(onChange);
            }

            bindToggleDisposables.Clear();

            for (var index = 0; index < bindScroll.Count; index++)
            {
                (ScrollRect.ScrollRectEvent toggle, UnityAction<Vector2> onChange) = bindScroll[index];
                toggle.RemoveListener(onChange);
            }

            bindScroll.Clear();

            for (var index = 0; index < bindScrollbar.Count; index++)
            {
                (Scrollbar.ScrollEvent toggle, UnityAction<float> onChange) = bindScrollbar[index];
                toggle.RemoveListener(onChange);
            }

            bindScrollbar.Clear();

            for (var index = 0; index < bindDropDownDisposables.Count; index++)
            {
                (TMP_Dropdown toggle, UnityAction<int> onChange) = bindDropDownDisposables[index];
                toggle.onValueChanged.RemoveListener(onChange);
            }

            bindDropDownDisposables.Clear();
        }

        public override void ClearViewModel()
        {
            base.ClearViewModel();

            if (ViewModel == null)
                return;

            ReleaseViewModel();
            if (ViewModel is IDisposable disposable)
                disposable.Dispose();

            ViewModel = null;
        }

        public override void Dispose()
        {
            ClearViewModel();
            base.Dispose();
        }

        protected void Bind<T>(ReadOnlyReactiveProperty<T> field, Action<T> onChange)
        {
            bindDisposables.Add(field.Subscribe(onChange));
        }

        protected void BindSilently<T>(ReadOnlyReactiveProperty<T> field, Action<T> onChange)
        {
            bindDisposables.Add(field.Skip(1).Subscribe(onChange));
        }

        protected void Bind<T>(ObservableList<T> field, Action<int> onChange)
        {
            bindDisposables.Add(field.ObserveCountChanged().Subscribe(onChange));
            onChange(field.Count);
        }

        protected void BindCollectionRemove<T>(ObservableList<T> field, Action<T> onChange)
        {
            bindDisposables.Add(field.ObserveRemove().Subscribe(x => onChange.Invoke(x.Value)));
        }

        protected void BindCollectionAdd<T>(ObservableList<T> field, Action<T> onChange)
        {
            bindDisposables.Add(field.ObserveAdd().Subscribe(x => onChange.Invoke(x.Value)));
        }

        protected void BindDictionaryAdd<TKey, TValue>(ObservableDictionary<TKey, TValue> field, Action<TKey, TValue> onChange)
        {
            bindDisposables.Add(field.ObserveAdd().Subscribe(x => onChange.Invoke(x.Value.Key, x.Value.Value)));
        }

        protected void BindDictionaryRemove<TKey, TValue>(ObservableDictionary<TKey, TValue> field, Action<TKey, TValue> onChange)
        {
            bindDisposables.Add(field.ObserveRemove().Subscribe(x => onChange.Invoke(x.Value.Key, x.Value.Value)));
        }

        protected void BindClick(Button button, UnityAction onClick)
        {
            button.onClick.AddListener(onClick);
            bindButtonDisposables.Add((button, onClick));
        }

        protected void BindScrollValue(ScrollRect.ScrollRectEvent button, UnityAction<Vector2> onClick)
        {
            button.AddListener(onClick);
            bindScroll.Add((button, onClick));
        }

        protected void BindScrollbarValue(Scrollbar.ScrollEvent button, UnityAction<float> onClick)
        {
            button.AddListener(onClick);
            bindScrollbar.Add((button, onClick));
        }
    }
}