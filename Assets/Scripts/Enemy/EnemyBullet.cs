using Infrastructure;
using Player;
using UnityEngine;

namespace Enemy
{
    public sealed class EnemyBullet : Bullet
    {
        protected override void OnCollisionEnter(Collision collision)
        {
            base.OnCollisionEnter(collision);
            
            if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
                playerHealth.TryTakeDamage(Damage);
        }
    }
}