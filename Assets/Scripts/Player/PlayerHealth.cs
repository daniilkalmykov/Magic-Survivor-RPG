using System;
using System.Collections;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement), typeof(PlayerRotation), typeof(PlayerAttacker))]
    public sealed class PlayerHealth : Health
    {
        private PlayerAttacker _playerAttacker;
        private PlayerMovement _playerMovement;
        private PlayerRotation _playerRotation;

        public event Action<int, int> Changed;

        protected override void Awake()
        {
            base.Awake();
            
            _playerAttacker = GetComponent<PlayerAttacker>();
            _playerMovement = GetComponent<PlayerMovement>();
            _playerRotation = GetComponent<PlayerRotation>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            
            _playerAttacker.enabled = true;
            _playerMovement.enabled = true;
            _playerRotation.enabled = true;
        }
        
        public override void TryTakeDamage(int damage)
        {
            base.TryTakeDamage(damage);
            Changed?.Invoke(CurrentHealth, MaxHealth);
        }

        public override void ResetValues()
        {
            base.ResetValues();
            Changed?.Invoke(CurrentHealth, MaxHealth);
        }

        protected override IEnumerator DieCoroutine()
        {
            _playerAttacker.enabled = false;
            _playerMovement.enabled = false;
            _playerRotation.enabled = false;
            
            return base.DieCoroutine();
        }
    }
}