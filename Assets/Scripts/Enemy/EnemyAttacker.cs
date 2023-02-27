using System;
using Player;
using UnityEngine;

namespace Enemy
{
    public sealed class EnemyAttacker : Attacker
    {
        [SerializeField] private EnemyAttackingTrigger _enemyAttackingTrigger;
        [SerializeField] private float _damage;
        
        private PlayerHealth _playerHealth;
        
        public Transform Player { get; private set; }
        
        private void Start()
        {
            if (Player.TryGetComponent(out PlayerHealth playerHealth))
                _playerHealth = playerHealth;
            else
                throw new ArgumentNullException();
            
            _enemyAttackingTrigger.Init(AttackDistance);
        }

        private void Update()
        {
            if (CanAttack && _enemyAttackingTrigger.IsOpponentInTrigger)
            {
                Attack();
            }
            else
            {
                if (IsCoroutineStarted == false)
                    StartCoroutine(WaitTimeBetweenAttacks());
            }
        }

        public void Init(Transform player)
        {
            Player = player;
        }

        protected override void Attack()
        {
            _playerHealth.TakeDamage(_damage);
            SwitchAttackStateToFalse();
        }
    }   
}