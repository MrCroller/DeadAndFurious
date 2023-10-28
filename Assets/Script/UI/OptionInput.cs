using DF.Associations;
using DF.Extension;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace DF.UI
{
    internal class OptionInput : MonoBehaviour
    {
        public const string MIXER_MASTER = "MasterVolume";
        public const string MIXER_MUSIC = "MusicVolume";
        public const string MIXER_EFFECT = "EffectVolume";
        public const string MIXER_VOICE = "VoiceVolume";

        public const float MIN_SOUND_VELOCITY = -50f;
        public const float MAX_SOUND_VELOCITY = 0f;

        public Slider SliderMaster;
        public Slider SliderMusic;
        public Slider SliderEffect;
        public Slider SliderVoice;

        public Button RestartButton = default;
        public Button ExitButton = default;

        [field: SerializeField] public AudioMixer AudioMixer { get; private set; }

        private void Start()
        {
            AudioMixer.GetFloat(MIXER_MASTER, out float value);
            SliderMaster.value = Mathf.InverseLerp(MIN_SOUND_VELOCITY, MAX_SOUND_VELOCITY, value);
            SliderMaster.Add(ChangeMasterVolume);

            AudioMixer.GetFloat(MIXER_MUSIC, out value);
            SliderMusic.value = Mathf.InverseLerp(MIN_SOUND_VELOCITY, MAX_SOUND_VELOCITY, value);
            SliderMusic.Add(ChangeMusicVolume);

            AudioMixer.GetFloat(MIXER_EFFECT, out value);
            SliderEffect.value = Mathf.InverseLerp(MIN_SOUND_VELOCITY, MAX_SOUND_VELOCITY, value);
            SliderEffect.Add(ChangeEffectVolume);

            AudioMixer.GetFloat(MIXER_VOICE, out value);
            SliderVoice.value = Mathf.InverseLerp(MIN_SOUND_VELOCITY, MAX_SOUND_VELOCITY, value);
            SliderVoice.Add(ChangeVoiceVolume);

            RestartButton.Add(RestartButtonHandler);
            ExitButton.Add(ExitButtonHandler);
        }
        private void OnDestroy()
        {
            SliderMaster.Remove(ChangeMasterVolume);
            SliderMusic.Remove(ChangeMusicVolume);
            SliderVoice.Remove(ChangeVoiceVolume);
            SliderEffect.Remove(ChangeEffectVolume);

            RestartButton.Remove(RestartButtonHandler);
            ExitButton.Remove(ExitButtonHandler);
        }

        private void ChangeMasterVolume(float volume)
        {
            AudioMixer.SetFloat(MIXER_MASTER, Mathf.Lerp(MIN_SOUND_VELOCITY, MAX_SOUND_VELOCITY, volume));
        }

        private void ChangeMusicVolume(float volume)
        {
            AudioMixer.SetFloat(MIXER_MUSIC, Mathf.Lerp(MIN_SOUND_VELOCITY, MAX_SOUND_VELOCITY, volume));
        }

        private void ChangeEffectVolume(float volume)
        {
            AudioMixer.SetFloat(MIXER_EFFECT, Mathf.Lerp(MIN_SOUND_VELOCITY, MAX_SOUND_VELOCITY, volume));
        }

        private void ChangeVoiceVolume(float volume)
        {
            AudioMixer.SetFloat(MIXER_VOICE, Mathf.Lerp(MIN_SOUND_VELOCITY, MAX_SOUND_VELOCITY, volume));
        }

        private void RestartButtonHandler()
        {
            SceneManager.LoadScene(SceneAssociations.Game);
        }

        private void ExitButtonHandler()
        {
            Application.Quit();
        }
    }
}
