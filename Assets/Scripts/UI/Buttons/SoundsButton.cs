using GameLogic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class SoundsButton : GameButton
    {
        [SerializeField] private Sprite _mutedSound;
        [SerializeField] private Sprite _unMutedSound;
        [SerializeField] private Image _sound;
        [SerializeField] private AudioListener _audioListener;
        
        private bool _isMuted;
        
        protected override void OnClick()
        {
            if (_isMuted)
                UnMute();
            else
                Mute();
        }

        private void Mute()
        {
            _isMuted = true;
            _sound.sprite = _mutedSound;
            _audioListener.enabled = false;
            
            SoundMuter.Mute();
        }

        private void UnMute()
        {
            _isMuted = false;
            _sound.sprite = _unMutedSound;
            _audioListener.enabled = true;
            
            SoundMuter.Unmute();
        }
    }
}