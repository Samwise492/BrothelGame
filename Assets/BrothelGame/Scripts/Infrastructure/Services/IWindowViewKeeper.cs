using System.Collections.Generic;
using BrothelGame.Infrastructure.Core;
using BrothelGame.Infrastructure.Data;

namespace BrothelGame.Infrastructure.Services
{
    public interface IWindowViewKeeper
    {
        public Dictionary<WindowId, View> Views { get; }
    }
}