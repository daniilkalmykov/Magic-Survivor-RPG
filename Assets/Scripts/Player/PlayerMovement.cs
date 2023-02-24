using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody), typeof(Animator))]
    public sealed class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        
        private Rigidbody _rigidbody;
        private Animator _animator;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetFloat(AnimatorStates.IsRunning, _rigidbody.velocity.magnitude);
        }

        public void Move(float directionX, float directionZ)
        {
            _rigidbody.velocity = new Vector3(directionX * _movementSpeed, _rigidbody.velocity.y,
                directionZ * _movementSpeed);
        }
    }
}
