using Player;
using UnityEngine;

namespace UI
{
    public sealed class PlayerHealthBar : Bar
    {
        [SerializeField] private PlayerHealth _playerHealth;
        
        private void OnEnable()
        {
            _playerHealth.Changed += OnValueChanged;
        }

        private void OnDisable()
        {
            _playerHealth.Changed -= OnValueChanged;
        }

        private void Start()
        {
            SetStartValues(_playerHealth.MaxHealth, _playerHealth.MaxHealth);
        }
    }
}