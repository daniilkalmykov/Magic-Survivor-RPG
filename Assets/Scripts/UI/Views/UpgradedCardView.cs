using System;
using Infrastructure.UpgradedCards;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views
{
    [RequireComponent(typeof(UpgradedCard), typeof(Button))]
    public sealed class UpgradedCardView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _level;

        private UpgradedCard _upgradedCard;
        private Button _button;

        public event Action Chose;

        private void Awake()
        {
            _upgradedCard = GetComponent<UpgradedCard>();
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
            
            _level.text = _upgradedCard.Level.ToString();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }
        
        private void OnClick()
        {
            _upgradedCard.MakeChosen();
            
            Chose?.Invoke();
        }
    }
}