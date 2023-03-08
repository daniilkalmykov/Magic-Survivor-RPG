using UnityEngine;

namespace Infrastructure.UpgradedCards
{
    public abstract class UpgradedCard : MonoBehaviour
    {
        public int Level { get; private set; }
        public bool IsChosen { get; private set; }
        
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
        }
    }
}