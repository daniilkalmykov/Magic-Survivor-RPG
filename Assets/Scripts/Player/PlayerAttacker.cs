using System.Collections;
using Constants;
using GameLogic;
using Infrastructure;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public sealed class PlayerAttacker : Attacker
    {
        private const int MinAttacksCountToShootPoisonBullet = 3;
        
        [SerializeField] private PlayerAttackingTrigger _playerAttackingTrigger;
        [SerializeField] private PlayerBullet _playerBullet;
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private PlayerPoisonBullet _playerPoisonBullet;
        [SerializeField] private int _attacksCountToShootPoisonBullet;
        [SerializeField] private int _reducingAttacksCountToShootPoisonBullet;

        private Animator _animator;
        private Transform _enemy;
        private int _currentAttacksCountToShootPoisonBullet;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _playerAttackingTrigger.EnemyDetected += OnEnemyDetected;
        }

        private void OnDisable()
        {
            _playerAttackingTrigger.EnemyDetected -= OnEnemyDetected;
        }

        private void Start()
        {
            _playerAttackingTrigger.Init(AttackDistance);
            
            _playerBullet.ResetDamage();
            
            _playerPoisonBullet.Deactivate();
            _playerPoisonBullet.ResetDamage();
            _playerPoisonBullet.Poison.ResetValues();
        }

        private void Update()
        {
            if (CanAttack && _playerAttackingTrigger.IsOpponentInTrigger)
            {
                Attack();
            }
            else if(CanAttack == false)
            {
                if (IsCoroutineStarted == false)
                    StartCoroutine(WaitTimeBetweenAttacks());
            }
        }

        public override void IncreaseDamage()
        {
            _playerBullet.IncreaseDamage();
        }

        public void ReduceAttacksCountToShootPoisonBullet()
        {
            _attacksCountToShootPoisonBullet -= _reducingAttacksCountToShootPoisonBullet;

            if (_attacksCountToShootPoisonBullet <= MinAttacksCountToShootPoisonBullet)
                _attacksCountToShootPoisonBullet = MinAttacksCountToShootPoisonBullet;
        }
        
        protected override void Attack()
        {
            if(_enemy == null)
                return;

            if (_currentAttacksCountToShootPoisonBullet < _attacksCountToShootPoisonBullet) 
            {
                SpawnBullet(_playerBullet);
                _currentAttacksCountToShootPoisonBullet++;
            }
            else
            {
                if (_playerPoisonBullet.IsActivated)
                    SpawnBullet(_playerPoisonBullet);

                _currentAttacksCountToShootPoisonBullet = 0;
            }

            SwitchAttackStateToFalse();
                        
            _animator.SetTrigger(AnimatorStates.Attack);
        }

        private void SpawnBullet(Bullet bullet)
        {
            var newBullet = Instantiate(bullet, _bulletSpawnPoint);
            newBullet.Init(_enemy);
            newBullet.transform.SetParent(null);
        }
        
        private void OnEnemyDetected(Transform enemy)
        {
            _enemy = enemy;
        }

        protected override IEnumerator WaitTimeBetweenAttacks()
        {
            _playerAttackingTrigger.SetStartRadius();
            
            SwitchCoroutineStartedStateToTrue();
            
            yield return new WaitForSeconds(Delay);
            SwitchAttackStateToTrue();

            SwitchCoroutineStatedStateToFalse();
            
            _playerAttackingTrigger.SetInitRadius();
        }
    }
}