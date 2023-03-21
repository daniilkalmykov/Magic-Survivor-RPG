using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]    
    public sealed class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        
        private PlayerMovement _playerMovement;
        private PlayerRotation _playerRotation;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
            _playerRotation = GetComponent<PlayerRotation>();
        }

        private void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            if (horizontal == 0 && vertical == 0)
            {
                _playerMovement.Move(_joystick.Horizontal, _joystick.Vertical);
                _playerRotation.Rotate(_joystick.Horizontal, _joystick.Vertical);
            }
            else
            {
                _playerMovement.Move(horizontal, vertical);
                _playerRotation.Rotate(horizontal, vertical);
            }
        }
    }
}
