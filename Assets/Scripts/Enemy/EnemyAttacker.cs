using System;
using Constants;
using GameLogic;
using Player;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Animator))]
    public abstract class EnemyAttacker : Attacker
    {
        [SerializeField] private EnemyAttackingTrigger _enemyAttackingTrigger;

        private Animator _animator;

        public EnemyAttackingTrigger EnemyAttackingTrigger => _enemyAttackingTrigger;
        public Transform Player { get; private set; }
        protected PlayerHealth PlayerHealth { get; private set; }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        protected virtual void Start()
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
                _animator.SetTrigger(AnimatorStates.Attack);
                Attack();
            }
            else
            {
                if (IsCoroutineStarted == false)
                    StartCoroutine(WaitTimeBetweenAttacks());
            }

            var playerPosition = Player.position;
            transform.LookAt(new Vector3(playerPosition.x, transform.position.y, playerPosition.z));
        }
        
        public void Init(Transform player)
        {
            Player = player;
        }
    }
}