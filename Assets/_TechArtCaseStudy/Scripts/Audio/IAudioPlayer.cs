namespace Appodeal.TechartCaseStudy.AudioEffect
{

    // Open closed principle, in case we will switch to another audio engine in future like fmod
    public interface IAudioPlayer
    {
        public void PlayOneShot(AudioType type, float volume = 1f);
    }
}
