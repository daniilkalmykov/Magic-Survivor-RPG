using System.Collections;
using Agava.YandexGames;
using GameLogic;
using UI;
using UI.Panels;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement), typeof(PlayerRotation), typeof(PlayerAttacker))]
    public sealed class PlayerHealth : Health
    {
        [SerializeField] private DeathPanel _deathPanel;
        
        private PlayerAttacker _playerAttacker;
        private PlayerMovement _playerMovement;
        private PlayerRotation _playerRotation;

        protected override void Awake()
        {
            base.Awake();
            
            _playerAttacker = GetComponent<PlayerAttacker>();
            _playerMovement = GetComponent<PlayerMovement>();
            _playerRotation = GetComponent<PlayerRotation>();

            _deathPanel.gameObject.SetActive(false);
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
        
        protected override void Die()
        {
            base.Die();
            _deathPanel.gameObject.SetActive(true);
        }
    }
}