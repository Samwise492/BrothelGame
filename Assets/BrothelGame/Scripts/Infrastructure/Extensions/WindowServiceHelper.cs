using System.Collections.Generic;
using BrothelGame.Infrastructure.Core;

namespace BrothelGame.Infrastructure.Extensions
{
    public static class WindowServiceHelper
    {
        public static T Cast<T>(this View view) where T : View => view as T;
    }
}