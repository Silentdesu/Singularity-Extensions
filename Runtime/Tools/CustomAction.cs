using System;

namespace SingularityLab.Runtime.Tools
{
    public partial class CustomAction
    {
        private Action _action;

        public void AddListener(in Action action)
        {
            _action += action;
        }

        public void RemoveListener(in Action action)
        {
            _action -= action;
        }

        public void RemoveAllListeners()
        {
            _action = null;
        }

        /// <summary>
        /// Checking for null.
        /// </summary>
        public void Invoke()
        {
            _action?.Invoke();
        }
    }

    public partial class CustomAction<T>
    {
        private Action<T> _action;

        public void AddListener(in Action<T> action)
        {
            _action += action;
        }

        public void RemoveListener(in Action<T> action)
        {
            _action -= action;
        }

        public void RemoveAllListeners()
        {
            _action = null;
        }

        /// <summary>
        /// Checking for null.
        /// </summary>
        public void Invoke(T arg)
        {
            _action?.Invoke(arg);
        }
    }

    public partial class CustomAction<T1, T2>
    {
        private Action<T1, T2> _action;

        public void AddListener(in Action<T1, T2> action)
        {
            _action += action;
        }

        public void RemoveListener(in Action<T1, T2> action)
        {
            _action -= action;
        }

        public void RemoveAllListeners()
        {
            _action = null;
        }

        /// <summary>
        /// Checking for null.
        /// </summary>
        public void Invoke(T1 arg1, T2 arg2)
        {
            _action?.Invoke(arg1, arg2);
        }
    }

    public partial class CustomAction<T1, T2, T3>
    {
        private Action<T1, T2, T3> _action;

        public void AddListener(in Action<T1, T2, T3> action)
        {
            _action += action;
        }

        public void RemoveListener(in Action<T1, T2, T3> action)
        {
            _action -= action;
        }

        public void RemoveAllListeners()
        {
            _action = null;
        }

        /// <summary>
        /// Checking for null.
        /// </summary>
        public void Invoke(in T1 arg1, in T2 arg2, in T3 arg3)
        {
            _action?.Invoke(arg1, arg2, arg3);
        }
    }
}