using Enemy;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CapsuleCollider))]
    public sealed class PlayerAttackingTrigger : MonoBehaviour
    {
        private CapsuleCollider _capsuleCollider;
        private EnemyHealth _enemyHealth;
        
        public bool IsEnemyInTrigger { get; private set; }

        private void Awake()
        {
            _capsuleCollider = GetComponent<CapsuleCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyHealth enemyHealth))
            {
                IsEnemyInTrigger = true;
                _enemyHealth = enemyHealth;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out EnemyHealth enemyHealth))
                IsEnemyInTrigger = false;
        }

        public void Init(float radius)
        {
            _capsuleCollider.radius = radius;
        }

        public EnemyHealth GetEnemyHealth()
        {
            return _enemyHealth;
        }
    }
}
