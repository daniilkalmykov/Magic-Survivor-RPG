using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.UpgradedCards;
using UnityEngine;

namespace GameLogic
{
    public abstract class UpgradedCardsPool : MonoBehaviour
    {
        private readonly List<UpgradedCard> _pool = new();

        protected void Init(UpgradedCard upgradedCard, Transform parent)
        {
            var newUpgradedCard = Instantiate(upgradedCard, transform.position, Quaternion.identity, parent);
            newUpgradedCard.gameObject.SetActive(false);
            newUpgradedCard.MakeNonChosen();
            
            _pool.Add(newUpgradedCard);
        }

        protected bool TryGetUpgradedCardToChoose(out UpgradedCard upgradedCard, List<UpgradedCard> cardsToChoose)
        {
            upgradedCard = _pool.FirstOrDefault(card =>
                card.gameObject.activeSelf == false && cardsToChoose.Contains(card) == false);

            return upgradedCard != null;
        }

        protected UpgradedCard GetUpgradedCard(int index)
        {
            if (index < 0 || index >= _pool.Count)
                throw new ArgumentNullException();
            
            return _pool[index];
        }

        protected List<UpgradedCard> GetUpgradedCardsInPool()
        {
            return _pool;
        }
    }
}