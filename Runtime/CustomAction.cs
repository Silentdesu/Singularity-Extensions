using System;

namespace SingularityLab.Runtime
{
    public partial class CustomAction
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

        public void RemoveAllListeners()
        {
            _action = null;
        }

        public void Invoke()
        {
            _action?.Invoke();
        }
    }

    public partial class CustomAction<T>
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
        
        public void RemoveAllListeners()
        {
            _action = null;
        }

        public void Invoke(T arg)
        {
            _action?.Invoke(arg);
        }
    }
}