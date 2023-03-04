﻿using System.Collections;
using UnityEngine;

namespace GameLogic
{
    public abstract class Attacker : MonoBehaviour
    {
        [SerializeField] private float _attackDistance;
        [SerializeField] private float _delay;

        protected bool IsCoroutineStarted { get; private set; }
        protected bool CanAttack { get; private set; }
        protected float AttackDistance => _attackDistance;

        public abstract void IncreaseDamage();
        
        protected IEnumerator WaitTimeBetweenAttacks()
        {
            IsCoroutineStarted = true;
            
            yield return new WaitForSeconds(_delay);
            CanAttack = true;

            IsCoroutineStarted = false;
        }

        protected void SwitchAttackStateToFalse()
        {
            CanAttack = false;
        }
    
        protected abstract void Attack();
    }
}