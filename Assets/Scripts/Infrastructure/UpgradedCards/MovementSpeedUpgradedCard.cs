﻿using Player;

namespace Infrastructure.UpgradedCards
{
    public sealed class MovementSpeedUpgradedCard : UpgradedCard
    {
        private PlayerMovement _playerMovement;

        public void Init(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }
        
        public override void UpgradeLevel()
        {
            base.UpgradeLevel();
            _playerMovement.IncreaseMovementSpeed(Level);
        }
    }
}