using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.UpgradedCards;
using Player;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic
{
    public sealed class UpgradedCardsGenerator : UpgradedCardsPool
    {
        [SerializeField] private List<UpgradedCard> _upgradedCards = new();
        [SerializeField] private int _choosingUpgradedCardsCount;
        [SerializeField] private PlayerExperience _playerExperience;
        [SerializeField] private Image _upgradedCardsPanel;
        [SerializeField] private PlayerAttacker _playerAttacker;
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private PlayerMovement _playerMovement;

        private readonly List<UpgradedCard> _generatedCards = new();

        private void Awake()
        {
            _upgradedCardsPanel.gameObject.SetActive(false);
            
            for (var i = 0; i < _upgradedCards.Count; i++)
            {
                Init(_upgradedCards[i], _upgradedCardsPanel.transform);

                var card = GetUpgradedCard(i);

                if (card.TryGetComponent(out IPlayerAttackerUpgradedCard playerAttackerUpgradedCard))
                    playerAttackerUpgradedCard.Init(_playerAttacker);
                else if (card.TryGetComponent(out HealthUpgradedCard healthUpgradedCard))
                    healthUpgradedCard.Init(_playerHealth);
                else if (card.TryGetComponent(out MovementSpeedUpgradedCard movementSpeedUpgradedCard))
                    movementSpeedUpgradedCard.Init(_playerMovement);
                else
                    throw new ArgumentNullException();
            }
        }

        private void OnEnable()
        {
            _playerExperience.LevelChanged += OnLevelChanged;

            foreach (var upgradedCard in GetUpgradedCardsInPool())
            {
                if (upgradedCard.TryGetComponent(out UpgradedCardView upgradedCardView))
                    upgradedCardView.Chose += OnChoose;
            }
        }

        private void OnDisable()
        {
            _playerExperience.LevelChanged -= OnLevelChanged;
            
            foreach (var upgradedCard in GetUpgradedCardsInPool())
            {
                if (upgradedCard.TryGetComponent(out UpgradedCardView upgradedCardView))
                    upgradedCardView.Chose -= OnChoose;
            }
        }

        private void Start()
        {
            while (_choosingUpgradedCardsCount > _upgradedCards.Count)
                _choosingUpgradedCardsCount--;
        }
        
        private void OnLevelChanged()
        {
            if(_playerExperience.Level <= 1)
                return;

            Time.timeScale = 0;
            _upgradedCardsPanel.gameObject.SetActive(true);

            for (var i = 0; i < _choosingUpgradedCardsCount; i++)
            {
                if (TryGetUpgradedCardToChoose(out var upgradedCard, _generatedCards))
                {
                    SetCardToChoose(upgradedCard);
                    _generatedCards.Add(upgradedCard);
                }
                else
                {
                    throw new ArgumentNullException();
                }                
            }
        }
        
        private void OnChoose()
        {
            Time.timeScale = 1;
            _upgradedCardsPanel.gameObject.SetActive(false);

            var chosenCard = _generatedCards.FirstOrDefault(card => card.IsChosen);

            if (chosenCard == null)
                throw new ArgumentNullException();

            chosenCard.UpgradeLevel();

            foreach (var card in _generatedCards)
            {
                card.MakeNonChosen();
                card.gameObject.SetActive(false);
            }
            
            _generatedCards.Clear();
        }

        private void SetCardToChoose(UpgradedCard upgradedCard)
        {
            if (upgradedCard == null)
                throw new ArgumentNullException();
            
            upgradedCard.MakeNonChosen();
            upgradedCard.gameObject.SetActive(true);
        }
    }
}