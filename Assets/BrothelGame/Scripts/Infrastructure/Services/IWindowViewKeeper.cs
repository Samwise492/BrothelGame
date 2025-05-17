using System.Collections.Generic;
using BrothelGame.Infrastructure.Core;
using BrothelGame.Windows;

namespace BrothelGame.Infrastructure.Services
{
    public interface IWindowViewKeeper
    {
        public Dictionary<WindowId, View> Views { get; }
    }
}