using Player;

namespace Infrastructure.UpgradedCards.Interfaces
{
    public interface IPlayerDeadZoneUpgradedCard
    {
        PlayerDeadZone PlayerDeadZone { get; }

        void Init(PlayerDeadZone playerDeadZone);
    }
}