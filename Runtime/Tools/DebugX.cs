using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Debug = UnityEngine.Debug;

namespace SingularityLab.Runtime.Tools
{
    public static class DebugX
    {
        private const string EventManagerDebuggerHeader = "<color=yellow>#</color><color=#9a52ff><b>Event: </b></color>";
        private const string RunOnStartDebuggerHeader = "<color=yellow>☺</color><color=#52ff9d><b>RunOnStart: </b></color>";
        private const string StatDataDebuggerHeader = "<color=yellow>✎</color><color=#ffda73><b>StatData: </b></color>";
        private const string ManagerDebuggerHeader = "<color=yellow>♕</color><color=#73b4ff><b>Manager: </b></color>";
        private const string AudioDebuggerHeader = "<color=yellow>♪</color><color=#e1ff73><b>Audio: </b></color>";
        private const string UIDebuggerHeader = "<color=yellow>★</color><color=#ff73ef><b>UI: </b></color>";
        private const string TrackDebuggerHeader = "<color=yellow>☛</color><color=#ffff78><b>Track: </b></color>";
        private const string LoadingDebuggerHeader = "<color=yellow>⌛</color><color=#ff7878><b>SceneLoading: </b></color>";
        private const string LoadedDebuggerHeader = "<color=yellow>☑</color><color=#78fff6><b>SceneLoaded: </b></color>";
        private const string UnloadedDebuggerHeader = "<color=yellow>☑</color><color=#ffffff><b>SceneUnloaded: </b></color>";
        private const string ErrorDebuggerHeader = "<color=yellow>☒</color><color=#ff0000><b>Error: </b></color>";
        private const string WarningDebuggerHeader = "<color=yellow>‼️</color><color=#ffff78><b>Warnning: </b></color>";
        private const string SuccessDebuggerHeader = "<color=yellow>☑</color><color=#11ff00><b>Success: </b></color>";
        
        private static readonly StringBuilder _stringBuilder = new StringBuilder();

        [Conditional("UNITY_EDITOR"), Conditional("DEVELOPMENT_BUILD")]
        private static void Log(ReadOnlySpan<char> messageType, ReadOnlySpan<char> message)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD

            _stringBuilder.Clear();
            _stringBuilder.Append(messageType);
            _stringBuilder.Append(message);

            Debug.unityLogger.Log(_stringBuilder);
#endif
        }

        public static void Event(ReadOnlySpan<char> message)
        {
            Log(EventManagerDebuggerHeader, message);
        }

        public static void OnStart(ReadOnlySpan<char> message)
        {
            Log(RunOnStartDebuggerHeader, message);
        }

        public static void Data(ReadOnlySpan<char> message)
        {
            Log(StatDataDebuggerHeader, message);
        }
        
        public static void Manager(ReadOnlySpan<char> message)
        {
            Log(ManagerDebuggerHeader, message);
        }
        
        public static void Audio(ReadOnlySpan<char> message)
        {
            Log(AudioDebuggerHeader, message);
        }
        
        public static void UI(ReadOnlySpan<char> message)
        {
            Log(UIDebuggerHeader, message);
        }

        public static void Track(ReadOnlySpan<char> message)
        {
            Log(TrackDebuggerHeader, message);
        }
        
        public static void Count<T>(IEnumerable<T> enumerable)
        {
            ReadOnlySpan<char> temp = $"Count => {enumerable.Count()}";
            Log(StatDataDebuggerHeader, temp);
        }

        public static void SceneLoading(ReadOnlySpan<char> message)
        {
            Log(LoadingDebuggerHeader, message);
        }
        
        public static void SceneLoaded(ReadOnlySpan<char> message)
        {
            Log(LoadedDebuggerHeader, message);
        }
        
        public static void SceneUnloaded(ReadOnlySpan<char> message)
        {
            Log(UnloadedDebuggerHeader, message);
        }
        
        public static void Error(ReadOnlySpan<char> message)
        {
            Log(ErrorDebuggerHeader, message);
        }
        
        public static void Warning(ReadOnlySpan<char> message)
        {
            Log(WarningDebuggerHeader, message);
        }
        
        public static void Success(ReadOnlySpan<char> message)
        {
            Log(SuccessDebuggerHeader, message);
        }
    }
}