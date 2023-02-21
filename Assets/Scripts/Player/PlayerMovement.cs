using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        
        private Rigidbody _rigidbody;
        private CharacterController _characterController;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _characterController = GetComponent<CharacterController>();
        }

        public void Move(float directionX, float directionZ)
        {
            var velocity = new Vector3(_movementSpeed * directionX, _rigidbody.velocity.y, _movementSpeed * directionZ);
            _characterController.Move(velocity * Time.deltaTime);
        }
    }
}
