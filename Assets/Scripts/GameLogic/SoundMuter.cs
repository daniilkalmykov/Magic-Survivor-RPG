using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(AudioListener))]
    public sealed class SoundMuter : MonoBehaviour
    {
        private static bool s_isMuted;

        private AudioListener _audioListener;

        private void Awake()
        {
            _audioListener = GetComponent<AudioListener>();
        }

        private void Start()
        {
            _audioListener.enabled = !s_isMuted;
        }

        public static void Mute()
        {
            s_isMuted = true;
        }

        public static void Unmute()
        {
            s_isMuted = false;
        }
    }
}