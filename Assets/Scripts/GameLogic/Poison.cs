using System;
using System.Collections;
using Enemy;
using UnityEngine;

namespace GameLogic
{
    public sealed class Poison : MonoBehaviour
    {
        private const float MinDelay = 0.1f;
        
        [SerializeField] private int _damage;
        [SerializeField] private int _ticksCount;
        [SerializeField] private float _delay;
        [SerializeField] private int _addingDamage;
        [SerializeField] private int _addingTicksCount;
        [SerializeField] private float _reducingDelay;

        private int _startDamage;
        private float _startDelay;
        private int _startTicksCount;
        
        private EnemyHealth _enemyHealth;

        private void OnValidate()
        {
            _startDamage = _damage;
            _startDelay = _delay;
            _startTicksCount = _ticksCount;
        }

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

        public void ReduceDelay(int level)
        {
            _delay -= _reducingDelay * level;

            if (_delay <= 0)
                _delay = MinDelay;
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