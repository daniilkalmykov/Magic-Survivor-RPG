using UnityEngine;

namespace Player
{
    public sealed class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private PlayerAttackingTrigger _playerAttackingTrigger;
        [SerializeField] private float _rotationSpeed;

        private Transform _enemy;

        private void OnEnable()
        {
            _playerAttackingTrigger.EnemyDetected += OnEnemyDetected;
        }

        private void OnDisable()
        {
            _playerAttackingTrigger.EnemyDetected -= OnEnemyDetected;
        }

        private void Update()
        {
            if (_playerAttackingTrigger.IsOpponentInTrigger == false)
            {
                if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
                {
                    var moveDirection = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

                    if (Vector3.Angle(transform.forward, moveDirection) > 0)
                    {
                        var newDirection = Vector3.RotateTowards(transform.forward, moveDirection,
                            _rotationSpeed * Time.deltaTime, 0);
                        transform.rotation = Quaternion.LookRotation(newDirection);
                    }
                }
            }
            else
            {
                var enemyPosition = _enemy.position;
                transform.LookAt(new Vector3(enemyPosition.x, transform.position.y, enemyPosition.z));
            }                
        }

        private void OnEnemyDetected(Transform enemy)
        {
            _enemy = enemy;
        }
    }
}