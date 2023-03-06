using System.Collections;
using UnityEngine;

namespace GameLogic
{
    public abstract class Attacker : MonoBehaviour
    {
        private const float MinDelay = 0.1f;
        
        [SerializeField] private float _attackDistance;
        [SerializeField] private float _delay;
        [SerializeField] private float _delayReducingValue;
        
        protected bool IsCoroutineStarted { get; private set; }
        protected bool CanAttack { get; private set; }
        protected float AttackDistance => _attackDistance;

        public void ReduceDelay()
        {
            _delay -= _delayReducingValue;

            if (_delay <= 0)
                _delay = MinDelay;
        }
        
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