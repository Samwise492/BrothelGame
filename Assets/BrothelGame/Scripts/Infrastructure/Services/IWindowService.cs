using System;
using System.Collections.Generic;
using System.Linq;
using BrothelGame.Windows;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace BrothelGame.Infrastructure.Services
{
    public interface IWindowService
    {
        void Initialize();
        bool IsWindowActive(WindowId windowId);
        void Open(WindowId id);
        void OpenWithArgs(WindowId id, object[] args);
        void Close(WindowId id);
    }
}