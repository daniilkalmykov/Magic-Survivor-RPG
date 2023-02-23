using System.Collections;
using UnityEngine;

namespace Player
{
    public sealed class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private PlayerAttackingTrigger _playerAttackingTrigger;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private float _shootingDistance;
        [SerializeField] private float _delay;

        private Transform _enemy;
        private bool _isCoroutineStarted;
        private bool _canShoot;

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
            _playerAttackingTrigger.Init(_shootingDistance);
        }

        private void Update()
        {
            if (_canShoot && _playerAttackingTrigger.IsEnemyInTrigger)
            {
                Shoot();
            }
            else if(_canShoot == false)
            {
                if (_isCoroutineStarted == false)
                    StartCoroutine(WaitTimeBetweenShots());
            }
        }

        private void Shoot()
        {
            if(_enemy == null)
                return;
            
            var newBullet = Instantiate(_bullet, _bulletSpawnPoint);
            newBullet.Init(_enemy);
            newBullet.transform.SetParent(null);
            
            _canShoot = false;
        }

        private void OnEnemyDetected(Transform enemy)
        {
            _enemy = enemy;
        }

        private IEnumerator WaitTimeBetweenShots()
        {
            _isCoroutineStarted = true;
            
            yield return new WaitForSeconds(_delay);
            _canShoot = true;

            _isCoroutineStarted = false;
        }
    }
}