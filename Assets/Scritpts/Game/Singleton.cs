using System;

namespace Game.Systems
{
    public class Singleton<T> : IDisposable where T : class
    {
        public static T Instance;

        protected Singleton()
        {
            Instance = this as T;
        }

        public virtual void Dispose()
        {
            Instance = null;
        }
    }
}