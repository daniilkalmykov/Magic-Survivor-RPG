using Player;
using UI.Panels;
using UnityEngine;
using YandexSDK;

namespace UI.Buttons
{
    public class DieRecoveryButton : GameButton
    {
        [SerializeField] private AdShower _adShower;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private DeathPanel _deathPanel;

        protected override void OnClick()
        {
            Recovery();
        }

        private void Recovery()
        {
            _playerHealth.gameObject.SetActive(true);
            _playerHealth.ResetValues();
            
            _deathPanel.gameObject.SetActive(false);
            
            _adShower.Show();
        }
    }
}