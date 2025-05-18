using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace BrothelGame.Infrastructure.Services
{
    internal sealed class PrefabFactory : IPrefabFactory
    {
        public T Instantiate<T>(string prefabName, Transform parent) where T : MonoBehaviour
        {
            T prefab = Resources.Load<T>(prefabName) ?? throw new Exception($"Can't load '{typeof(T)}' by path '{prefabName}'");
            T instantiate = Object.Instantiate(prefab, parent);

            return instantiate;
        }
    }
}