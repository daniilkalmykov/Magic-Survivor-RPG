using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerRotation : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private PlayerAttackingTrigger _playerAttackingTrigger;

        private Rigidbody _rigidbody;
        private Transform _enemy;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            _playerAttackingTrigger.EnemyDetected += OnEnemyDetected;
        }

        private void OnDisable()
        {
            _playerAttackingTrigger.EnemyDetected -= OnEnemyDetected;
        }

        private void LateUpdate()
        {
            if (_playerAttackingTrigger.IsEnemyInTrigger == false)
            {
                if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
                    transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
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