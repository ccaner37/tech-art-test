using UnityEngine;

namespace Appodeal.TechartCaseStudy.AudioEffect
{
    public class AudioService : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private UnityAudioClipSO _audioDatabase; // Assign your SO here in the Inspector

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

            // Inject both the AudioSource and the Data into the player
            _audioPlayer = new UnityAudioPlayer(_audioSource, _audioDatabase);
        }

        // The public API now just requires the type of sound you want to play
        public void PlaySound(AudioType type, float volume = 1f)
        {
            _audioPlayer?.PlayOneShot(type, volume);
        }
    }   
}