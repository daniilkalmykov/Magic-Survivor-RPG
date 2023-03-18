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

        protected override void OnEnable()
        {
            base.OnEnable();

            _adShower.ClosedCallBack += OnCloseCallBack;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _adShower.ClosedCallBack -= OnCloseCallBack;
        }

        protected override void OnClick()
        {
            ShowAdd();
        }

        private void ShowAdd()
        {
            _adShower.Show();
        }

        private void OnCloseCallBack()
        {
            Recovery();
        }
        
        private void Recovery()
        {
            _playerHealth.gameObject.SetActive(true);
            _playerHealth.ResetValues();
            
            Time.timeScale = 1;
            
            _deathPanel.gameObject.SetActive(false);
        }
    }
}