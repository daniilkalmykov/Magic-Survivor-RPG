using UnityEngine;

namespace Enemy
{
    public sealed class EnemyCloseAttacker : EnemyAttacker
    {
        [SerializeField] private int _damage;
        [SerializeField] private int _addingDamage;

        public override void IncreaseDamage()
        {
            _damage += _addingDamage;
        }

        protected override void Attack()
        {
            PlayerHealth.TryTakeDamage(_damage);
            SwitchAttackStateToFalse();
        }
    }   
}