namespace Appodeal.TechArtCaseStudy.AudioEffect
{

    // Open closed principle, in case we will switch to another audio engine in future like fmod
    public interface IAudioPlayer
    {
        public void PlayOneShot(GameAudioType type, float volume = 1f);
    }
}
