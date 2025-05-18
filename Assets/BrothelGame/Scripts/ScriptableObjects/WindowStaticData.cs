using System.Collections.Generic;
using BrothelGame.Infrastructure.Data;
using UnityEngine;

namespace BrothelGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WindowStaticData", menuName = "BrothelGame/WindowStaticData")]
    public class WindowStaticData : ScriptableObject
    {
        public WindowData[] Windows;
    }
}