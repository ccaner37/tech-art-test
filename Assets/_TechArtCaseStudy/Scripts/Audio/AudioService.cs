using UnityEngine;

namespace Appodeal.TechArtCaseStudy.AudioEffect
{
    public class AudioService : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private UnityAudioClipSO _audioDatabase;

        public static AudioService Instance { get; private set; }

        private IAudioPlayer _audioPlayer;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            DontDestroyOnLoad(gameObject);

            _audioPlayer = new UnityAudioPlayer(_audioSource, _audioDatabase);
        }

        public void PlaySound(GameAudioType type, float volume = 1f)
        {
            _audioPlayer?.PlayOneShot(type, volume);
        }
    }   
}
