using Infrastructure.UpgradedCards.Interfaces;
using Player;

namespace Infrastructure.UpgradedCards.PlayerAttackerCards
{
    public sealed class AttacksCountToShootPoisonBulletUpgradedCard : UpgradedCard, IPlayerAttackerUpgradedCard
    {
        public PlayerAttacker PlayerAttacker { get; private set; }
        
        public void Init(PlayerAttacker playerAttacker)
        {
            PlayerAttacker = playerAttacker;
        }

        public override void UpgradeLevel()
        {
            base.UpgradeLevel();
            PlayerAttacker.ReduceAttacksCountToShootPoisonBullet();
        }
    }
}