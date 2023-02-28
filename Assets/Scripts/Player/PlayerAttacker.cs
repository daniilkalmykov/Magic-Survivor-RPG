using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public sealed class PlayerAttacker : Attacker
    {
        [SerializeField] private PlayerAttackingTrigger _playerAttackingTrigger;
        [SerializeField] private PlayerBullet _playerBullet;
        [SerializeField] private Transform _bulletSpawnPoint;

        private Animator _animator;
        private Transform _enemy;

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

        protected override void Attack()
        {
            if(_enemy == null)
                return;
            
            var newBullet = Instantiate(_playerBullet, _bulletSpawnPoint);
            newBullet.Init(_enemy);
            newBullet.transform.SetParent(null);
            
            SwitchAttackStateToFalse();
        
            _animator.SetTrigger(AnimatorStates.IsShooting);
        }
        
        private void OnEnemyDetected(Transform enemy)
        {
            _enemy = enemy;
        }
    }
}