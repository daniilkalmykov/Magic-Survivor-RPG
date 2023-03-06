using Player;

namespace Infrastructure.UpgradedCards
{
    public sealed class HealthUpgradedCard : UpgradedCard
    {
        private PlayerHealth _playerHealth;

        public void Init(PlayerHealth playerHealth)
        {
            _playerHealth = playerHealth;
        }

        public override void UpgradeLevel()
        {
            base.UpgradeLevel();
            _playerHealth.Increase();
        }
    }
}