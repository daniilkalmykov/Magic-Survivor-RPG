using System;
using Enemy;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CapsuleCollider))]
    public sealed class PlayerAttackingTrigger : MonoBehaviour
    {
        private CapsuleCollider _capsuleCollider;
        private EnemyHealth _enemyHealth;

        public event Action<Transform> EnemyDetected; 

        public bool IsEnemyInTrigger { get; private set; }

        private void Awake()
        {
            _capsuleCollider = GetComponent<CapsuleCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyHealth enemyHealth) && enemyHealth.gameObject.activeSelf)
            {
                IsEnemyInTrigger = true;
                _enemyHealth = enemyHealth;

                EnemyDetected?.Invoke(_enemyHealth.transform);
                _enemyHealth.Died += OnDied;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out EnemyHealth enemyHealth) && enemyHealth == _enemyHealth) 
            {
                IsEnemyInTrigger = false;

                _enemyHealth.Died -= OnDied;
            }
        }

        public void Init(float radius)
        {
            _capsuleCollider.radius = radius;
        }

        private void OnDied()
        {
            IsEnemyInTrigger = false;
        }
    }
}
