using System;
using Enemy;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CapsuleCollider))]
    public sealed class PlayerAttackingTrigger : AttackingTrigger
    {
        private EnemyHealth _enemyHealth;

        public event Action<Transform> EnemyDetected; 

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyHealth enemyHealth) && enemyHealth.gameObject.activeSelf)
            {
                SwitchOpponentStateToTrue();
                _enemyHealth = enemyHealth;

                EnemyDetected?.Invoke(_enemyHealth.transform);
                _enemyHealth.Died += OnDied;
            }
        }

        protected override void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out EnemyHealth enemyHealth) && enemyHealth == _enemyHealth) 
            {
                SwitchOpponentStateToFalse();

                _enemyHealth.Died -= OnDied;
            }
        }
    }
}
