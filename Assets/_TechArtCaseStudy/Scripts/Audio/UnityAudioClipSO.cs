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
        public GameAudioType Type;
        public AudioClip Clip;

        public UnityAudioClipData(GameAudioType type, AudioClip clip)
        {
            Type = type;
            Clip = clip;
        }
    }

    public enum GameAudioType
    {
        ButtonClick,
        Progress,
        Success,
    }
}