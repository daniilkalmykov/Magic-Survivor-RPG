using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(AudioListener))]
    public sealed class SoundMuter : MonoBehaviour
    {
        [SerializeField] private AudioSource[] _audioSources;
        [SerializeField] private float[] _volumes;

        private static AudioSource[] s_audioSources;
        private static float[] s_volumes;
        
        private AudioListener _audioListener;

        public static bool IsMuted { get; private set; }

        private void Awake()
        {
            _audioListener = GetComponent<AudioListener>();

            s_audioSources = _audioSources;
            s_volumes = _volumes;
        }

        private void Start()
        {
            _audioListener.enabled = !IsMuted;
            
            if(IsMuted)
            {
                foreach (var audioSource in s_audioSources)
                    audioSource.volume = 0;
            }
            else
            {
                for (var i = 0; i < s_audioSources.Length; i++)
                    s_audioSources[i].volume = s_volumes[i];
            }   
        }

        public static void Mute()
        {
            IsMuted = true;

            foreach (var audioSource in s_audioSources)
                audioSource.volume = 0;
        }

        public static void Unmute()
        {
            IsMuted = false;

            for (var i = 0; i < s_audioSources.Length; i++)
                s_audioSources[i].volume = s_volumes[i];
        }
    }
}