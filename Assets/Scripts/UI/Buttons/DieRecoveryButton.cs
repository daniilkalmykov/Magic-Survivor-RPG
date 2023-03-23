using Player;
using UI.Panels;
using UnityEngine;
using YandexSDK;

namespace UI.Buttons
{
    public class DieRecoveryButton : GameButton
    {
        private const int MaxClicks = 1;
        
        [SerializeField] private AdShower _adShower;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private DeathPanel _deathPanel;

        private int _clicks;

        protected override void OnEnable()
        {
            base.OnEnable();

            if (_clicks == MaxClicks)
                Button.interactable = false;
        }

        protected override void OnClick()
        {
            Recovery();
        }

        private void Recovery()
        {
            _clicks++;
            
            _playerHealth.gameObject.SetActive(true);
            _playerHealth.ResetValues();
            
            _deathPanel.gameObject.SetActive(false);
            
            _adShower.Show();
        }
    }
}