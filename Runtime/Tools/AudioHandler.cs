namespace SingularityLab.Runtime.Tools
{
    using UnityEngine;
    using UnityEngine.Audio;

    public static class AudioHandler
    {
        /// <summary>
        /// Play clip once and then destroy it.
        /// </summary>
        /// <param name="mixer"></param>
        /// <param name="clip"></param>
        /// <param name="sfxPosition"></param>
        public static void PlayOneSFX(in AudioMixer mixer, in AudioClip clip, string groupName, Vector3 sfxPosition)
        {
            if (clip == null)
                return;

            GameObject sfxInstance = new GameObject(clip.name);

            sfxInstance.transform.position = sfxPosition;

            AudioSource source = sfxInstance.AddComponent<AudioSource>();
            source.clip = clip;
            source.Play();

            source.outputAudioMixerGroup = GetAudioMixerGroup(mixer, groupName);

            Object.Destroy(sfxInstance, clip.length);
        }

        /// <summary>
        /// Return an AudioMixerGroup by name.
        /// </summary>
        /// <param name="mixer"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public static AudioMixerGroup GetAudioMixerGroup(in AudioMixer mixer, string groupName)
        {
            AudioMixerGroup[] groups = mixer.FindMatchingGroups(groupName);

            foreach (AudioMixerGroup match in groups)
            {
                if (match.ToString() == groupName)
                    return match;
            }
            return null;
        }

        /// <summary>
        /// Convert linear value between 0 and 1 to decibels.
        /// </summary>
        /// <param name="linearValue"></param>
        /// <returns></returns>
        public static float GetDecibelValue(float linearValue)
        {
            // commonly used for linear to decibel conversion
            float conversionFactor = 20f;

            float decibelValue = (linearValue != 0) ? conversionFactor * Mathf.Log10(linearValue) : -144f;
            return decibelValue;
        }

        /// <summary>
        /// Convert decibel value to a range between 0 and 1.
        /// </summary>
        /// <param name="decibelValue"></param>
        /// <returns></returns>
        public static float GetLinearValue(float decibelValue)
        {
            float conversionFactor = 20f;

            return Mathf.Pow(10f, decibelValue / conversionFactor);

        }

        /// <summary>
        /// Converts linear value between 0 and 1 into decibels and sets AudioMixer level.
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="linearValue"></param>
        public static void SetVolume(in AudioMixer mixer, string groupName, float linearValue)
        {
            float decibelValue = GetDecibelValue(linearValue);

            mixer.SetFloat(groupName, decibelValue);
        }

        /// <summary>
        /// returns a value between 0 and 1 based on the AudioMixer's decibel value
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public static float GetVolume(in AudioMixer mixer, string groupName)
        {
            float decibelValue = 0f;
            mixer.GetFloat(groupName, out decibelValue);
            
            return GetLinearValue(decibelValue);
        }
    }
}
