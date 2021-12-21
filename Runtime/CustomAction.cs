using System;

namespace Singularity.Scripts.Utils
{
    public class CustomAction
    {
        private Action _action;

        public void AddListener(Action action)
        {
            _action += action;
        }
        
        public void RemoveListener(Action action)
        {
            _action -= action;
        }

        public void Invoke()
        {
            _action?.Invoke();
        }
    }

    public class CustomAction<T>
    {
        private Action<T> _action;

        public void AddListener(Action<T> action)
        {
            _action += action;
        }

        public void RemoveListener(Action<T> action)
        {
            _action -= action;
        }

        public void Invoke(T arg)
        {
            _action?.Invoke(arg);
        }
    }
}