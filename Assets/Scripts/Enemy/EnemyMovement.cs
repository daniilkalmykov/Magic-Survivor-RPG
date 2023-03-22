using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyAttacker))]
    public sealed class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        
        private Transform _player;
        private EnemyAttacker _enemyAttacker;

        private void Awake()
        {
            _enemyAttacker = GetComponent<EnemyAttacker>();
        }

        private void Start()
        {
            _player = _enemyAttacker.Player;
        }

        private void Update()
        {
            if (_player == null)
                return;

            if (_enemyAttacker.EnemyAttackingTrigger.IsOpponentInTrigger)
                return;
                
            var playerPosition = _player.position;
            
            transform.position =
                Vector3.MoveTowards(transform.position, playerPosition, _movementSpeed * Time.deltaTime);
        }
    }
}