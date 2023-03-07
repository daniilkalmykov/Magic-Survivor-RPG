using GameLogic;
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

        public PlayerPoisonBullet PlayerPoisonBullet => _playerPoisonBullet;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            
            _playerPoisonBullet.Poison.ResetValues();
            _playerPoisonBullet.Deactivate();
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

        public override void IncreaseDamage(int level)
        {
            _playerBullet.IncreaseDamage(level);
        }

        public void ReduceAttacksCountToShootPoisonBullet()
        {
            _attacksCountToShootPoisonBullet -= _reducingAttacksCountToShootPoisonBullet;

            if (_attacksCountToShootPoisonBullet <= 0)
                _attacksCountToShootPoisonBullet = MinAttacksCountToShootPoisonBullet;
        }
        
        protected override void Attack()
        {
            if(_enemy == null)
                return;
            
            if(_currentAttacksCountToShootPoisonBullet < _attacksCountToShootPoisonBullet)
            {
                var newBullet = Instantiate(_playerBullet, _bulletSpawnPoint);
                newBullet.Init(_enemy);
                newBullet.transform.SetParent(null);
            }
            else
            {
                if (_playerPoisonBullet.IsActivated)
                {
                    var newPoisonBulletBullet = Instantiate(_playerPoisonBullet, _bulletSpawnPoint);
                    newPoisonBulletBullet.Init(_enemy);
                    newPoisonBulletBullet.transform.SetParent(null);
                }

                _currentAttacksCountToShootPoisonBullet = 0;
            }

            _currentAttacksCountToShootPoisonBullet++;
            SwitchAttackStateToFalse();
                        
            _animator.SetTrigger(AnimatorStates.Attack);
        }
        
        private void OnEnemyDetected(Transform enemy)
        {
            _enemy = enemy;
        }
    }
}