using Player;

namespace Infrastructure.UpgradedCards
{
    public interface IPoisonUpgradedCard
    {
        PlayerPoisonBullet PlayerPoisonBullet { get; }

        void Init(PlayerPoisonBullet playerPoisonBullet);
    }
}