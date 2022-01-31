using UnityEngine;

namespace Singularity.Scripts.Utils
{
    public static class PrefsCenter
    {
        /// <summary>
        ///     Example how to create a prefs key.
        /// </summary>
        public static long Debug
        {
            get => PlayerPrefsX.GetLong("Debug",0);
            set
            {
                PlayerPrefsX.SetLong("Debug", value);
                PlayerPrefs.Save();
            }
        }
    }
}