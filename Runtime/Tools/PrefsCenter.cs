using System.Collections.Generic;
using UnityEngine;

namespace SingularityLab.Runtime.Tools
{
    public static partial class PrefsCenter
    {

#if UNITY_EDITOR
        //For PrefsExposerWindow tool
        public static List<string> Prefs = new List<string>();
#endif

        /// <summary>
        /// Example how to create a prefs key.
        /// </summary>
        public static float Debug
        {
            get
            {
                return PlayerPrefs.GetFloat("Debug", 0);
            }
            set
            {
                PlayerPrefs.SetFloat("Debug", value);
                Save("Debug"); // or Save(nameof(Debug));
            }
        }


        public static void Save(string prefs)
        {
            PlayerPrefs.Save();

#if UNITY_EDITOR
            //For PrefsExposerWindow tool
            if (!Prefs.Contains(prefs))
                Prefs.Add(prefs);
#endif
        }
    }
}