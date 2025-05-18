using System.Collections.Generic;
using BrothelGame.Infrastructure.Core;
using BrothelGame.Infrastructure.Data;

namespace BrothelGame.Infrastructure.Services
{
    public class WindowViewKeeper : IWindowViewKeeper
    {
        public Dictionary<WindowId, View> Views { get; private set; }

        public WindowViewKeeper()
        {
            Views = new Dictionary<WindowId, View>();
        }
    }
}