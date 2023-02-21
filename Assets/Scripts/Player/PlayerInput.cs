using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]    
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        
        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            _playerMovement.Move(_joystick.Horizontal, _joystick.Vertical);
        }
    }
}
