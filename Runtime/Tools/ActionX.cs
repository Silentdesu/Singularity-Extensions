using System;

namespace SingularityLab.Runtime.Tools
{
    /// <summary>
    /// This is struct so keep in mind if you want to use it then keep it in classes.
    /// 
    /// This struct was created as an analogue for class CustomAction.
    /// </summary>
    public struct ActionX
    {
        private Action _action;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="action"></param>
        /// <param name="invokeMethod">Invoke method after the subscription.</param>
        public void AddListener(in Action action, in bool invokeMethod = false)
        {
            _action += action;

            if (invokeMethod)
                action?.Invoke();
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
        public void InvokeSafe()
        {
            _action?.Invoke();
        }
    }

    public struct ActionX<T>
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
        /// <param name="arg"></param>
        public void InvokeSafe(T arg)
        {
            _action?.Invoke(arg);
        }
    }

    public struct ActionX<T1, T2>
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
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        public void InvokeSafe(T1 arg1, T2 arg2)
        {
            _action?.Invoke(arg1, arg2);
        }
    }

    public struct ActionX<T1, T2, T3>
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
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="arg3"></param>
        public void InvokeSafe(T1 arg1, T2 arg2, T3 arg3)
        {
            _action?.Invoke(arg1, arg2, arg3);
        }
    }
}
