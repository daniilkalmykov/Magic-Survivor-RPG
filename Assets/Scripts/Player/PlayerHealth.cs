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

        protected override IEnumerator DieCoroutine()
        {
            _playerAttacker.enabled = false;
            _playerMovement.enabled = false;
            _playerRotation.enabled = false;
            
            return base.DieCoroutine();
        }
    }
}