using Player;

namespace Infrastructure.UpgradedCards
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

            if (PlayerAttacker.PlayerPoisonBullet.IsActivated == false)
                PlayerAttacker.PlayerPoisonBullet.Activate();
            else
                PlayerAttacker.ReduceAttacksCountToShootPoisonBullet();
        }
    }
}