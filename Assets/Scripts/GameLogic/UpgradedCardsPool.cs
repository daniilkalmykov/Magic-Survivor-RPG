using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.UpgradedCards;
using UnityEngine;
using Random = UnityEngine.Random;

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
            for (var i = _pool.Count - 1; i >= 1; i--)
            {
                var randomNumber = Random.Range(0, i + 1);
                (_pool[randomNumber], _pool[i]) = (_pool[i], _pool[randomNumber]);
            }
            
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