using UnityEngine;

namespace Enemy
{
    public sealed class EnemyRangedAttacker : EnemyAttacker
    {
        [SerializeField] private EnemyBullet _enemyBullet;
        [SerializeField] private Transform _bulletSpawnPoint;
        
        protected override void Attack()
        {
            if(Player == null)
                return;

            var newBullet = Instantiate(_enemyBullet, _bulletSpawnPoint);
            newBullet.Init(Player);
            newBullet.transform.SetParent(null);
            
            SwitchAttackStateToFalse();
        }
    }
}