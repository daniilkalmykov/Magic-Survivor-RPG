using Player;
using UnityEngine;

namespace Infrastructure.Boosters
{
    public sealed class HealthBooster : Booster
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private int _addingHealth;

        protected override void OnCloseCallBack()
        {
            base.OnCloseCallBack();
            _playerHealth.TryIncrease(_addingHealth);
        }
    }
}