using Player;

namespace Infrastructure.UpgradedCards
{
    public sealed class DamageUpgradedCard : UpgradedCard, IPlayerAttackerUpgradedCard
    {
        public PlayerAttacker PlayerAttacker { get; private set; }

        public void Init(PlayerAttacker playerAttacker)
        {
            PlayerAttacker = playerAttacker;
        }

        public override void UpgradeLevel()
        {
            base.UpgradeLevel();
            PlayerAttacker.IncreaseDamage(Level);
        }
    }
}