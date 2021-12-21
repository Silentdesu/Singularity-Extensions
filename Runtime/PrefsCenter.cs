using UnityEngine;

namespace Singularity.Scripts.Utils
{
    public static class PrefsCenter
    {
        public static long Gold
        {
            get => PlayerPrefsX.GetLong("Gold",0);
            set
            {
                PlayerPrefsX.SetLong("Gold", value);
                PlayerPrefs.Save();
            }
        }
        
        public static long Gems
        {
            get => PlayerPrefsX.GetLong("Gems",0);
            set
            {
                PlayerPrefsX.SetLong("Gems", value);
                PlayerPrefs.Save();
            }
        }
        
        public static long Leadership
        {
            get => PlayerPrefsX.GetLong("Leadership",0);
            set
            {
                PlayerPrefsX.SetLong("Leadership", value);
                PlayerPrefs.Save();
            }
        }
        
        public static int WarriorActiveLevel
        {
            get => PlayerPrefs.GetInt("WarriorLevel", 1);
            set
            {
                PlayerPrefs.SetInt("WarriorLevel", value);
                PlayerPrefs.Save();
            }
        }
        
        public static int WarriorIdleLevel
        {
            get => PlayerPrefs.GetInt("WarriorIdleLevel", 1);
            set
            {
                PlayerPrefs.SetInt("WarriorIdleLevel", value);
                PlayerPrefs.Save();
            }
        }

        public static int TwoWarriorsActiveLevel
        {
            get => PlayerPrefs.GetInt("TwoWarriorActiveLevel", 1);
            set
            {
                PlayerPrefs.SetInt("TwoWarriorActiveLevel", value);
                PlayerPrefs.Save();
            }
        }
        
        public static int TwoWarriorsIdleLevel
        {
            get => PlayerPrefs.GetInt("TwoWarriorIdleLevel", 1);
            set
            {
                PlayerPrefs.SetInt("TwoWarriorIdleLevel", value);
                PlayerPrefs.Save();
            }
        }

        public static int ArcherActiveLevel
        {
            get => PlayerPrefs.GetInt("ArcherActiveLevel", 1);
            set
            {
                PlayerPrefs.SetInt("ArcherActiveLevel", value);
                PlayerPrefs.Save();
            }
        }

        public static int ArcherIdleLevel
        {
            get => PlayerPrefs.GetInt("ArcherIdleLevel", 1);
            set
            {
                PlayerPrefs.SetInt("ArcherIdleLevel", value);
                PlayerPrefs.Save();
            }
        }

        public static int MageActiveLevel
        {
            get => PlayerPrefs.GetInt("MageLevel", 1);
            set
            {
                PlayerPrefs.SetInt("MageLevel", value);
                PlayerPrefs.Save();
            }
        }
        
        public static int MageIdleLevel
        {
            get => PlayerPrefs.GetInt("MageIdleLevel", 1);
            set
            {
                PlayerPrefs.SetInt("MageIdleLevel", value);
                PlayerPrefs.Save();
            }
        }
        
        public static int Wave
        {
            get => PlayerPrefs.GetInt("Wave", 1);
            set
            {
                PlayerPrefs.SetInt("Wave", value);
                PlayerPrefs.Save();
            }
        }

        public static int MaxWave
        {
            get => PlayerPrefs.GetInt("MaxWave", 5);
            set
            {
                PlayerPrefs.SetInt("MaxWave", value);
                PlayerPrefs.Save();
            }
        }
    }
}