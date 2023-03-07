using Player;

namespace Infrastructure.UpgradedCards
{
    public interface IPlayerDeadZoneUpgradedCard
    {
        PlayerDeadZone PlayerDeadZone { get; }

        void Init(PlayerDeadZone playerDeadZone);
    }
}