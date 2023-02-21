using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _movementSpeed;
        
        private void Update()
        {
            if(_player == null)
                return;

            var playerPosition = _player.position;
            transform.position =
                Vector3.MoveTowards(transform.position, playerPosition, _movementSpeed * Time.deltaTime);
        }
    }
}