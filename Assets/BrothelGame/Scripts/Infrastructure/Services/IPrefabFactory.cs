using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BrothelGame.Infrastructure.Services
{
    public interface IPrefabFactory
    {
        T Instantiate<T>(string prefabName, Transform parent) where T : MonoBehaviour;
    }
}