using Player;

namespace Infrastructure.UpgradedCards
{
    public sealed class PlayerDeadZoneDamageUpgradedCard : UpgradedCard, IPlayerDeadZoneUpgradedCard
    {
        public PlayerDeadZone PlayerDeadZone { get; private set; }

        public void Init(PlayerDeadZone playerDeadZone)
        {
            PlayerDeadZone = playerDeadZone;
        }

        public override void UpgradeLevel()
        {
            base.UpgradeLevel();
            
            if(Level == 1)
                PlayerDeadZone.gameObject.SetActive(true);
            else
                PlayerDeadZone.IncreaseDamage(Level);
        }
    }
}