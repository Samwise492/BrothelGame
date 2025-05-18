using System;
using System.Collections;
using System.Collections.Generic;
using BrothelGame.Windows;
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