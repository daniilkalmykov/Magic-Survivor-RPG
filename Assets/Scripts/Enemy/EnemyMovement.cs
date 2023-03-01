using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyAttacker))]
    public sealed class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        
        private Transform _player;
        private EnemyAttacker _enemyCloseAttacker;

        private void Awake()
        {
            _enemyCloseAttacker = GetComponent<EnemyAttacker>();
        }

        private void Start()
        {
            _player = _enemyCloseAttacker.Player;
        }

        private void Update()
        {
            if (_player == null)
                return;

            var playerPosition = _player.position;
            transform.position =
                Vector3.MoveTowards(transform.position, playerPosition, _movementSpeed * Time.deltaTime);
        }
    }
}