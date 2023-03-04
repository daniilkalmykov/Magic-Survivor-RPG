using GameLogic;
using Player;
using UnityEngine;

namespace Enemy
{
    public sealed class EnemyAttackingTrigger : AttackingTrigger
    {
        private PlayerHealth _playerHealth;

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerHealth playerHealth) && playerHealth.IsDied == false)
            {
                SwitchOpponentStateToTrue();
                _playerHealth = playerHealth;

                _playerHealth.Died += OnDied;
            }
        }
        
        protected override void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerHealth playerHealth) && _playerHealth == playerHealth)
            {
                SwitchOpponentStateToFalse();

                _playerHealth.Died -= OnDied;
            }
        }
    }
}