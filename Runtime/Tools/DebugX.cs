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
        private static void Log(string messageType, string message)
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD   
            
            _stringBuilder.Clear();
            _stringBuilder.Append(messageType);
            _stringBuilder.Append(message);
                
            Debug.Log(_stringBuilder);
#endif
        }
            
        public static void Event(string message)
        {
            Log(EventManagerDebuggerHeader, message);
        }

        public static void OnStart(string message)
        {
            Log(RunOnStartDebuggerHeader, message);
        }

        public static void Data(string message)
        {
            Log(StatDataDebuggerHeader, message);
        }
        
        public static void Manager(string message)
        {
            Log(ManagerDebuggerHeader, message);
        }
        
        public static void Audio(string message)
        {
            Log(AudioDebuggerHeader, message);
        }
        
        public static void UI(string message)
        {
            Log(UIDebuggerHeader, message);
        }
        
        public static void Track(string message)
        {
            Log(TrackDebuggerHeader, message);
        }
        
        public static void Count<T>(IEnumerable<T> enumerable)
        {
            Log(StatDataDebuggerHeader, $"Count => {enumerable.Count()}");
        }

        public static void SceneLoading(string message)
        {
            Log(LoadingDebuggerHeader, message);
        }
        
        public static void SceneLoaded(string message)
        {
            Log(LoadedDebuggerHeader, message);
        }
        
        public static void SceneUnloaded(string message)
        {
            Log(UnloadedDebuggerHeader, message);
        }
        
        public static void Error(string message)
        {
            Log(ErrorDebuggerHeader, message);
        }
        
        public static void Warning(string message)
        {
            Log(WarningDebuggerHeader, message);
        }
        
        public static void Success(string message)
        {
            Log(SuccessDebuggerHeader, message);
        }
    }
}