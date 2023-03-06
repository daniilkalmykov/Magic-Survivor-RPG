using System;
using UnityEngine;

namespace Infrastructure.UpgradedCards
{
    public abstract class UpgradedCard : MonoBehaviour
    {
        public event Action<int> LevelChanged;
        
        public bool IsChosen { get; private set; }
        
        protected int Level { get; private set; }
        
        public void MakeChosen()
        {
            IsChosen = true;
        }

        public void MakeNonChosen()
        {
            IsChosen = false;
        }
        
        public virtual void UpgradeLevel()
        {
            Level++;
            LevelChanged?.Invoke(Level);
        }
    }
}