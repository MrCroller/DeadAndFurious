using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DF.Extension
{
    public static partial class Extension
    {
        public static void Play(this AudioSource source, AudioClip clip)
        {
            if (clip == null)
            {
                Debug.LogWarning("Отсутствует аудиоклип по событию");
                return;
            }

            source.clip = clip;
            source.Play();
        }
    }
}