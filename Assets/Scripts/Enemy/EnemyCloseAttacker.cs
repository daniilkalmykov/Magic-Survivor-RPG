﻿using UnityEngine;

namespace Enemy
{
    public sealed class EnemyCloseAttacker : EnemyAttacker
    {
        [SerializeField] private float _damage;
        
        protected override void Attack()
        {
            PlayerHealth.TryTakeDamage(_damage);
            SwitchAttackStateToFalse();
        }
    }   
}