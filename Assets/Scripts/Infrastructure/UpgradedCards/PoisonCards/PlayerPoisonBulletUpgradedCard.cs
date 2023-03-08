using Infrastructure.UpgradedCards.Interfaces;
using Player;

namespace Infrastructure.UpgradedCards.PoisonCards
{
    public sealed class PlayerPoisonBulletUpgradedCard : UpgradedCard, IPoisonUpgradedCard
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
                PlayerPoisonBullet.IncreaseDamage();                
        }
    }
}