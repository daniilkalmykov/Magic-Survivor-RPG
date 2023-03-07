using Player;

namespace Infrastructure.UpgradedCards
{
    public sealed class PoisonDamageUpgradedCard : UpgradedCard, IPoisonUpgradedCard
    {
        public PlayerPoisonBullet PlayerPoisonBullet { get; private set; }
        
        public void Init(PlayerPoisonBullet playerPoisonBullet)
        {
            PlayerPoisonBullet = playerPoisonBullet;
        }

        public override void UpgradeLevel()
        {
            base.UpgradeLevel();

            if (PlayerPoisonBullet.IsActivated == false)
                PlayerPoisonBullet.Activate();
            else
                PlayerPoisonBullet.Poison.IncreaseDamage(Level);
        }
    }
}