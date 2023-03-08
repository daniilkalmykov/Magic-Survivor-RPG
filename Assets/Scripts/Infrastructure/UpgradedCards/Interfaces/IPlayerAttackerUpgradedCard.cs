using Player;

namespace Infrastructure.UpgradedCards.Interfaces
{
    public interface IPlayerAttackerUpgradedCard
    {
        PlayerAttacker PlayerAttacker { get; }

        void Init(PlayerAttacker playerAttacker);
    }
}