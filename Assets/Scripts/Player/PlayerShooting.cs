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

        private bool _isCoroutineStarted;
        private bool _canShoot;

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
            var newBullet = Instantiate(_bullet, _bulletSpawnPoint);
            newBullet.Init(_playerAttackingTrigger.GetEnemyHealth().transform);
           
            _canShoot = false;
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