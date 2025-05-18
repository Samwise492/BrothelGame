using System;
using UnityEngine;

namespace BrothelGame.Infrastructure.Data
{
    [Serializable]
    public class WindowData
    {
        public WindowId Id;
        public MonoBehaviour Hierarchy;
    }
}