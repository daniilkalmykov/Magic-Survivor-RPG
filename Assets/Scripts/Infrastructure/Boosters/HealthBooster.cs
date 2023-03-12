using System;
using Agava.YandexGames;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Boosters
{
    public sealed class HealthBooster : Booster
    {
        [SerializeField] private Image _boostersPanel;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private int _health;

        private Action _rewardedCallBack;

        protected override void OnEnable()
        {
            base.OnEnable();
            _rewardedCallBack += OnRewardedCallBack;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _rewardedCallBack -= OnRewardedCallBack;
        }

        protected override void OnClick()
        {
            VideoAd.Show(onRewardedCallback: _rewardedCallBack);
        }

        private void OnRewardedCallBack()
        {
            _playerHealth.IncreaseByBooster(_health);
            _boostersPanel.gameObject.SetActive(false);
        }
    }
}