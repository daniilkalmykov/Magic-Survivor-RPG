using Enemy;
using Infrastructure;
using UnityEngine;

namespace Player
{
    public sealed class PlayerBullet : Bullet
    {
        protected override void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out EnemyHealth enemyHealth))
                enemyHealth.TryTakeDamage(Damage);
            
            base.OnCollisionEnter(collision);
        }
    }
}