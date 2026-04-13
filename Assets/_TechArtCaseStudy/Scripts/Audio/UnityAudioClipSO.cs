using System;
using UnityEngine;

namespace Appodeal.TechartCaseStudy.AudioEffect
{
    [CreateAssetMenu(fileName = "New UnityAudioClip", menuName = "Audio/UnityAudioClip")]
    public class UnityAudioClipSO : ScriptableObject
    {
        [SerializeField] private UnityAudioClipData[] _audioClips;

        public UnityAudioClipData[] Clips => _audioClips;
    }

    [Serializable]
    public class UnityAudioClipData
    {
        public AudioType Type;
        public AudioClip Clip;

        public UnityAudioClipData(AudioType type, AudioClip clip)
        {
            Type = type;
            Clip = clip;
        }
    }

    public enum AudioType
    {
        ButtonClick,
        Progress,
        Success,
    }
}