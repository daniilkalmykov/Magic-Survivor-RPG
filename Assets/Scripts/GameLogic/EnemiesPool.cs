using System.Collections.Generic;
using System.Linq;
using Enemy;
using UnityEngine;

namespace GameLogic
{
    public abstract class EnemiesPool : MonoBehaviour
    {
        private readonly List<EnemyAttacker> _pool = new();

        protected void Init(EnemyAttacker enemyCloseAttacker, int count, Vector3 spawnPoint)
        {
            for (var i = 0; i < count; i++)
            {
                var newEnemy = Instantiate(enemyCloseAttacker, spawnPoint, Quaternion.identity);
                newEnemy.gameObject.SetActive(false);
                newEnemy.transform.SetParent(null);
            
                _pool.Add(newEnemy);
            }
        }

        protected bool TryGetEnemy(out EnemyAttacker enemyCloseAttacker)
        {
            enemyCloseAttacker = _pool.FirstOrDefault(result => result.gameObject.activeSelf == false);

            return enemyCloseAttacker != null;
        }

        protected List<EnemyAttacker> GetEnemiesInPool()
        {
            return _pool;
        }
    }
}