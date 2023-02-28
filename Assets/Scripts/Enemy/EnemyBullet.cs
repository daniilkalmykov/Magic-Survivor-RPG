using Player;
using UnityEngine;

namespace Enemy
{
    public class EnemyBullet : Bullet
    {
        protected override void OnCollisionEnter(Collision collision)
        {
            base.OnCollisionEnter(collision);
            
            if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
                playerHealth.TakeDamage(Damage);
        }
    }
}