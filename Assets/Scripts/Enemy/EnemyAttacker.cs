using System;
using Player;
using UnityEngine;

namespace Enemy
{
    public abstract class EnemyAttacker : Attacker
    {
        [SerializeField] private EnemyAttackingTrigger _enemyAttackingTrigger;
        
        public Transform Player { get; private set; }
        protected PlayerHealth PlayerHealth { get; private set; }
        
        private void Start()
        {
            if (Player.TryGetComponent(out PlayerHealth playerHealth))
                PlayerHealth = playerHealth;
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
    }
}