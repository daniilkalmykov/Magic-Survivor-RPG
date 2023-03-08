using System;
using System.Collections;
using Enemy;
using UnityEngine;

namespace GameLogic
{
    public sealed class Poison : MonoBehaviour
    {
        [SerializeField] private int _damage;
        [SerializeField] private int _ticksCount;
        [SerializeField] private float _delay;
        [SerializeField] private int _addingDamage;
        [SerializeField] private int _addingTicksCount;
        [SerializeField]private int _startDamage;
        [SerializeField] private float _startDelay;
        [SerializeField] private int _startTicksCount;

        
        private EnemyHealth _enemyHealth;

        private void Start()
        {
            StartCoroutine(Attack());
        }

        public void Init(EnemyHealth enemyHealth)
        {
            _enemyHealth = enemyHealth;
        }

        public void IncreaseDamage(int level)
        {
            _damage += _addingDamage * level;
        }

        public void IncreaseTicksCount()
        {
            _addingDamage += _addingTicksCount;
        }

        public void ResetValues()
        {
            _damage = _startDamage;
            _delay = _startDelay;
            _ticksCount = _startTicksCount;
        }

        private IEnumerator Attack()
        {
            if (_enemyHealth == null)
                throw new ArgumentNullException();
            
            var delay = new WaitForSeconds(_delay);
            
            for (var i = 0; i < _ticksCount; i++)
            {
                _enemyHealth.TryTakeDamage(_damage);
                
                yield return delay;
            }
            
            Destroy(gameObject);
        }
    }
}