using System;
using System.Collections.Generic;
using System.Linq;
using BrothelGame.Infrastructure.Data;
using BrothelGame.Windows;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace BrothelGame.Infrastructure.Services
{
    public interface IWindowService
    {
        void Initialize();
        void Clear();
        bool IsWindowActive(WindowId windowId);
        void Open(WindowId id);
        void OpenWithArgs(WindowId id, object[] args);
        void Close(WindowId id);
    }
}