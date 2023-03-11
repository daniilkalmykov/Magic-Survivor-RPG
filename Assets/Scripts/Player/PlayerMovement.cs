using Constants;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody), typeof(Animator))]
    public sealed class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _addingMovementSpeed;
        
        private Rigidbody _rigidbody;
        private Animator _animator;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetFloat(AnimatorStates.Speed, _rigidbody.velocity.magnitude);
        }

        public void Move(float directionX, float directionZ)
        {
            _rigidbody.velocity = new Vector3(directionX * _movementSpeed, _rigidbody.velocity.y,
                directionZ * _movementSpeed);
        }

        public void IncreaseMovementSpeed()
        {
            _movementSpeed += _addingMovementSpeed;
        }
    }
}
