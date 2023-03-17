using Player;
using UnityEngine;

namespace Infrastructure.Boosters
{
    public sealed class AttackDistanceBooster : Booster
    {
        [SerializeField] private PlayerAttacker _playerAttacker;
        [SerializeField] private float _addingRadius;

        protected override void OnClick()
        { 
            base.OnClick();
            _playerAttacker.TryIncreaseAttackDistance(_addingRadius);
        }
    }
}