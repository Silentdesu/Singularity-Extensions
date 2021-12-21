using UnityEngine;

namespace Singularity.Scripts.Utils
{
    public static class DebugX
    {
        private const string EventManagerDebugerHeader = "<color=yellow>#</color><color=#9a52ff><b>Event: </b></color>";
        private const string RunOnStartDebugerHeader = "<color=yellow>☺</color><color=#52ff9d><b>RunOnStart: </b></color>";
        private const string StatDataDebugerHeader = "<color=yellow>✎</color><color=#ffda73><b>StatData: </b></color>";
        private const string ManagerDebugerHeader = "<color=yellow>♕</color><color=#73b4ff><b>Manager: </b></color>";
        private const string AudioDebugerHeader = "<color=yellow>♪</color><color=#e1ff73><b>Audio: </b></color>";
        private const string UIDebugerHeader = "<color=yellow>★</color><color=#ff73ef><b>UI: </b></color>";
        private const string TrackDebugerHeader = "<color=yellow>☛</color><color=#ffff78><b>Track: </b></color>";
        private const string LoadingDebugerHeader = "<color=yellow>⌛</color><color=#ff7878><b>SceneLoading: </b></color>";
        private const string LoadedDebugerHeader = "<color=yellow>☑</color><color=#78fff6><b>SceneLoaded: </b></color>";
        private const string UnloadedDebugerHeader = "<color=yellow>☑</color><color=#ffffff><b>SceneUnloaded: </b></color>";
        private const string ErrorDebugerHeader = "<color=yellow>☒</color><color=#ff0000><b>Error: </b></color>";
        private const string WarrnigDebugerHeader = "<color=yellow>‼️</color><color=#ff0000><b>Warnning: </b></color>";
        private const string SuccessDebugerHeader = "<color=yellow>☑</color><color=#11ff00><b>Success: </b></color>";
        
        public static void Event(string message)
        {
            Debug.Log(EventManagerDebugerHeader + message);
        }

        public static void OnStart(string message)
        {
            Debug.Log(RunOnStartDebugerHeader + message);
        }

        public static void Data(string message)
        {
            Debug.Log(StatDataDebugerHeader + message);
        }
        
        public static void Manager(string message)
        {
            Debug.Log(ManagerDebugerHeader + message);
        }
        
        public static void Audio(string message)
        {
            Debug.Log(AudioDebugerHeader + message);
        }
        
        public static void UI(string message)
        {
            Debug.Log(UIDebugerHeader + message);
        }
        
        public static void Track(string message)
        {
            Debug.Log(TrackDebugerHeader + message);
        }
        
        public static void SceneLoading(string message)
        {
            Debug.Log(LoadingDebugerHeader + message);
        }
        
        public static void SceneLoaded(string message)
        {
            Debug.Log(LoadedDebugerHeader + message);
        }
        
        public static void SceneUnloaded(string message)
        {
            Debug.Log(UnloadedDebugerHeader + message);
        }
        
        public static void Error(string message)
        {
            Debug.Log(ErrorDebugerHeader + message);
        }
        
        public static void Warning(string message)
        {
            Debug.Log(WarrnigDebugerHeader + message);
        }
        
        public static void Success(string message)
        {
            Debug.Log(SuccessDebugerHeader + message);
        }
    }
}