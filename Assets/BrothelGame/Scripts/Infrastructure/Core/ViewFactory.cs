using BrothelGame.Infrastructure.Data;
using BrothelGame.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace BrothelGame.Infrastructure.Core
{
	internal sealed class ViewFactory : IViewFactory
	{
		private readonly IInstantiator instantiator;
		private readonly IPrefabFactory prefabFactory;
		private readonly IStaticDataService staticDataService;

		public ViewFactory(IInstantiator instantiator, IPrefabFactory prefabFactory, IStaticDataService staticDataService)
		{
			this.staticDataService = staticDataService;
			this.instantiator = instantiator;
			this.prefabFactory = prefabFactory;
		}

		public TView CreateView<TView, THierarchy>(WindowId id, Transform parent)
			where TView : View<THierarchy>
			where THierarchy : MonoBehaviour
		{
			WindowData windowData = staticDataService.GetWindowData(id);
			TView view = CreateView<TView, THierarchy>(windowData.Hierarchy, parent);
			return view;
		}

		public TView CreateView<TView, THierarchy>(THierarchy hierarchy)
			where TView : View<THierarchy>
			where THierarchy : MonoBehaviour
		{
			TView view = instantiator.Instantiate<TView>(new object[] { hierarchy });
			return view;
		}

		public TView CreateView<TView, THierarchy>(string prefabName, Transform parent)
			where TView : View<THierarchy>
			where THierarchy : MonoBehaviour
		{
			THierarchy hierarchy = prefabFactory.Instantiate<THierarchy>(prefabName, parent);

			return CreateView<TView, THierarchy>(hierarchy);
		}

		public TView CreateView<TView, THierarchy>(MonoBehaviour prefabName, Transform parent)
			where TView : View<THierarchy>
			where THierarchy : MonoBehaviour
		{
			MonoBehaviour instantiate;

			if (parent != null)
			{
				instantiate = Object.Instantiate(prefabName, parent);
			}
			else
			{
				instantiate = Object.Instantiate(prefabName);
			}

			return CreateView<TView, THierarchy>(instantiate.GetComponent<THierarchy>());
		}

		public TView CreateView<TView, THierarchy>(MonoBehaviour prefabName, Transform parent, MonoBehaviour parentHierarchy)
			where TView : View<THierarchy>
			where THierarchy : MonoBehaviour
		{
			MonoBehaviour hierarchy = parent != null ? Object.Instantiate(prefabName, parent) : Object.Instantiate(prefabName);
			TView view = instantiator.Instantiate<TView>(new object[] { hierarchy, parentHierarchy });
			return view;
		}
	}
}