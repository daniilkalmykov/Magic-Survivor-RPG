using UnityEngine;

namespace Enemy
{
    public sealed class EnemyCloseAttacker : EnemyAttacker
    {
        [SerializeField] private int _damage;
        
        protected override void Attack()
        {
            PlayerHealth.TryTakeDamage(_damage);
            SwitchAttackStateToFalse();
        }
    }   
}