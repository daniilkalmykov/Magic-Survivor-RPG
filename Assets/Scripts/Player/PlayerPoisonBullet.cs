using Enemy;
using GameLogic;
using Infrastructure;
using UnityEngine;

namespace Player
{
    public sealed class PlayerPoisonBullet : Bullet
    {
        [SerializeField] private Poison _poison;
        
        public Poison Poison => _poison;
        public bool IsActivated { get; private set; }

        public void Activate()
        {
            IsActivated = true;
        }

        public void Deactivate()
        {
            IsActivated = false;
        }
        
        protected override void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
            {
                enemyHealth.TryTakeDamage(Damage);
                
                var enemyTransform = enemyHealth.transform;
                var poison = Instantiate(_poison, enemyTransform.position, Quaternion.identity, enemyTransform);
                poison.Init(enemyHealth);
            }

            base.OnCollisionEnter(collision);
        }
    }
}