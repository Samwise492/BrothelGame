using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System;
using System.Linq;
using BrothelGame.Windows;
using BrothelGame.Infrastructure.Core;
using BrothelGame.Windows.DialogueWindow;
using BrothelGame.Infrastructure.Extensions;
using BrothelGame.Infrastructure.Data;

namespace BrothelGame.Infrastructure.Services
{
    public class WindowService : IWindowService
    {
        delegate void OpenOperation();
        delegate void OpenOperationWithArgs(object[] args);

        private readonly IInstantiator _instantiator;
        private readonly IWindowViewKeeper _windowsViewKeeper;
        private readonly IWindowViewFactory _windowViewFactory;

        private Dictionary<WindowId, View> Views => _windowsViewKeeper.Views;

        private readonly Dictionary<WindowId, OpenOperation> _methods = new();
        private readonly Dictionary<WindowId, OpenOperationWithArgs> _methodsWithArgs = new();

        public WindowService(IInstantiator instantiator,
            IWindowViewKeeper windowsViewKeeper,
            IWindowViewFactory windowViewFactory)
        {
            _instantiator = instantiator;
            _windowsViewKeeper = windowsViewKeeper;
            _windowViewFactory = windowViewFactory;
        }

        public void Initialize()
        {
            //_methodsWithArgs.Add(WindowId.Dialogue, OpenDialogueWindow);

            _methods.Add(WindowId.Dialogue, OpenDialogueWindow);

            _windowViewFactory.CreateDialogueWindow();

            TurnOffAllViews();
        }

        public void Clear()
        {
            _methods.Clear();
            _methodsWithArgs.Clear();
            Views.Clear();
        }

        public void Open(WindowId id)
        {
            if (Views.ContainsKey(id) && _methods.ContainsKey(id))
            {
                View view = Views[id];

                if (view.IsActive())
                {
                    return;
                }
                view.ClearViewModel();
                _methods[id].Invoke();
                view.SetActive(true);
            }
            else if (_methods.ContainsKey(id))
            {
                _methods[id].Invoke();
            }
        }

        public void OpenWithArgs(WindowId id, object[] args)
        {
            View view = Views[id];
            view.ClearViewModel();
            _methodsWithArgs[id].Invoke(args);
            view.SetActive(true);
        }

        public void Close(WindowId id)
        {
            View view = Views[id];
            view.ClearViewModel();
            view.SetActive(false);
        }

        public bool IsWindowActive(WindowId windowId)
        {
            if (!Views.ContainsKey(windowId))
            {
                return false;
            }

            View view = Views[windowId];
            bool status = view.IsActive();

            return status;
        }

        private void OpenDialogueWindow()
        {
            View view = Views[WindowId.Dialogue];
            var viewModel = Instantiate<DialogueWindowViewModel>();
            view.Cast<DialogueWindowView>().Initialize(viewModel);
        }

        private T Instantiate<T>() where T : IViewModel
        {
            return _instantiator.Instantiate<T>();
        }

        private T InstantiateWithArgs<T>(object[] args) where T : IViewModel
        {
            return _instantiator.Instantiate<T>(args);
        }

        private void TurnOffAllViews()
        {
            foreach (View view in Views.Values)
            {
                view.SetActive(false);
            }
        }
    }
}