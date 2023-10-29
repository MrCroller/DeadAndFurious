using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DF.Extension;
using UnityEngine;
using UnityEngineTimers;

namespace DF.Input
{
    internal class MusicManager : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _fightMusic;

        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _effectSource;

        private TimersPool _timers;

        private void Start()
        {
            _timers = TimersPool.GetInstance();

            _timers.StartTimer(MusicPlay2, _fightMusic[0].length - .05f);
            _musicSource.Play(_fightMusic[0]);

            void MusicPlay2()
            {
                _timers.StartTimer(MusicPlay3, _fightMusic[1].length - .05f);
                _musicSource.Play(_fightMusic[1]);
            }

            void MusicPlay3()
            {
                _timers.StartTimer(MusicPlay2, _fightMusic[2].length - .05f);
                _musicSource.Play(_fightMusic[2]);
            }
        }

        public void PlayEffect(AudioClip effect)
        {
            _effectSource.Play(effect);
        }
    }
}
