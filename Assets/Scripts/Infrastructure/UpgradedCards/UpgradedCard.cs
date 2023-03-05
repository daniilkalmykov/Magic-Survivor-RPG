using System;
using UnityEngine;

namespace Infrastructure.UpgradedCards
{
    public abstract class UpgradedCard : MonoBehaviour
    {
        public event Action<int> LevelChanged;
        
        public int Id { get; private set; }

        public int InitialLevel { get; private set; } = 1;
        public bool IsChosen { get; private set; }
        
        protected int Level { get; private set; }
        
        public void SetCardLevel(int value)
        {
            if (value >= Level)
                Level = value;
            else
                throw new ArgumentNullException();
        }
        
        public void MakeChosen()
        {
            IsChosen = true;
        }

        public void MakeNonChosen()
        {
            IsChosen = false;
        }
        
        public void UpgradeLevel()
        {
            Level++;
            LevelChanged?.Invoke(Level);
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}