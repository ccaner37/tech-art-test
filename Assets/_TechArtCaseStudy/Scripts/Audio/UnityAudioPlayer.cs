
using System.Collections.Generic;
using UnityEngine;

namespace Appodeal.TechArtCaseStudy.AudioEffect
{
    public class UnityAudioPlayer : IAudioPlayer
    {
        private readonly AudioSource _audioSource;
        private readonly Dictionary<GameAudioType, AudioClip> _clipDictionary;

        public UnityAudioPlayer(AudioSource audioSource, UnityAudioClipSO audioData)
        {
            _audioSource = audioSource;
            _clipDictionary = new Dictionary<GameAudioType, AudioClip>();

            if (audioData != null && audioData.Clips != null)
            {
                foreach (var data in audioData.Clips)
                {
                    if (!_clipDictionary.ContainsKey(data.Type))
                    {
                        _clipDictionary.Add(data.Type, data.Clip);
                    }
                }
            }
        }

        public void PlayOneShot(GameAudioType type, float volume = 1f)
        {
            if (_clipDictionary.TryGetValue(type, out AudioClip clip))
            {
                if (clip != null && _audioSource != null)
                {
                    _audioSource.PlayOneShot(clip, volume);
                }
            }
            else
            {
                Debug.LogWarning($"[AudioPlayer] No AudioClip found for AudioType: {type}");
            }
        }
    }
}
