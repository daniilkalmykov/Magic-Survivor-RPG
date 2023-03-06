using Player;

namespace Infrastructure.UpgradedCards
{
    public interface IPlayerAttackerUpgradedCard
    {
        PlayerAttacker PlayerAttacker { get; }

        void Init(PlayerAttacker playerAttacker);
    }
}