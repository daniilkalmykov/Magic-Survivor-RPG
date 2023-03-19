using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(AudioListener))]
    public sealed class SoundMuter : MonoBehaviour
    {
        private AudioListener _audioListener;

        public static bool IsMuted { get; private set; }

        private void Awake()
        {
            _audioListener = GetComponent<AudioListener>();
        }

        private void Start()
        {
            _audioListener.enabled = !IsMuted;
        }

        public static void Mute()
        {
            IsMuted = true;
        }

        public static void Unmute()
        {
            IsMuted = false;
        }
    }
}