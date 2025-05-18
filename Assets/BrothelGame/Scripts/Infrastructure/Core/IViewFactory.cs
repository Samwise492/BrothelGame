using UnityEngine;
using BrothelGame.Infrastructure.Data;

namespace BrothelGame.Infrastructure.Core
{
	public interface IViewFactory
	{
		TView CreateView<TView, THierarchy>(WindowId id, Transform parent = null)
			where TView : View<THierarchy> where THierarchy : MonoBehaviour;

		TView CreateView<TView, THierarchy>(THierarchy hierarchy)
			where TView : View<THierarchy>
			where THierarchy : MonoBehaviour;

		TView CreateView<TView, THierarchy>(string prefabName, Transform parent)
			where TView : View<THierarchy>
			where THierarchy : MonoBehaviour;

		TView CreateView<TView, THierarchy>(MonoBehaviour prefab, Transform parent)
			where TView : View<THierarchy>
			where THierarchy : MonoBehaviour;

		TView CreateView<TView, THierarchy>(MonoBehaviour prefabName, Transform parent, MonoBehaviour parentHierarchy)
			where TView : View<THierarchy>
			where THierarchy : MonoBehaviour;

	}
}