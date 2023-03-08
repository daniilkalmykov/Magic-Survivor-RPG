using Player;

namespace Infrastructure.UpgradedCards.Interfaces
{
    public interface IPoisonUpgradedCard
    {
        PlayerPoisonBullet PlayerPoisonBullet { get; }

        void Init(PlayerPoisonBullet playerPoisonBullet);
    }
}