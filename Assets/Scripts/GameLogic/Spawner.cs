using System;
using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameLogic
{
    public sealed class Spawner : EnemiesPool
    {
        [SerializeField] private Transform _player;
        [SerializeField] private List<Wave> _waves;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private float _timeBetweenWaves;

        public event Action TurnedOff;

        private int _currentWaveNumber;
        private int _spawnedEnemiesCount;
        private float _timeAfterLastEnemySpawned;

        public Wave CurrentWave { get; private set; }

        private void Start()
        {
            ResetOptions();
        
            Init(CurrentWave.EnemyAttacker, CurrentWave.EnemiesCount, transform.position);
        }

        private void Update()
        {
            if(CurrentWave == null)
                return;

            _timeAfterLastEnemySpawned += Time.deltaTime;

            if (_timeAfterLastEnemySpawned >= CurrentWave.Delay)
            {
                if(TryGetEnemy(out var enemyAttacker))
                {
                    SetEnemy(enemyAttacker);
                    _spawnedEnemiesCount++;
                    _timeAfterLastEnemySpawned = 0;
                }
            }

            if (_spawnedEnemiesCount >= CurrentWave.EnemiesCount)
            {
                CurrentWave = null;
                StartCoroutine(WaitTimeBetweenWaves());

                if (_currentWaveNumber == _waves.Count - 1)
                {
                    CurrentWave = null;
                    TurnedOff?.Invoke();
                }
            }
        }

        /*public void IncreaseEnemiesStats(int experienceValue, int damageValue, int healthValue)
    {
        var enemies = GetEnemiesInPool();

        foreach (var enemy in enemies)
        {
            if(enemy.TryGetComponent(out EnemyAttacker enemyAttacker))
                enemyAttacker.IncreaseDamage(damageValue);
        
            if(enemy.TryGetComponent(out EnemyHealth enemyHealth))
                enemyHealth.IncreaseMaxHealth(healthValue);
        
            if(enemy.TryGetComponent(out EnemyReward enemyReward))
                enemyReward.IncreaseExperience(experienceValue);
        }
    }*/

        public void IncreaseEnemiesStats()
        {
            var enemies = GetEnemiesInPool();

            foreach (var enemy in enemies)
            {
                if (enemy.TryGetComponent(out EnemyHealth enemyHealth))
                    enemyHealth.Increase();
                
                enemy.IncreaseDamage();
            }
        }
    
        public void ResetOptions()
        {
            _spawnedEnemiesCount = 0;
            _currentWaveNumber = 0;
            SetWave(_currentWaveNumber);
        }

        private IEnumerator WaitTimeBetweenWaves()
        {
            yield return new WaitForSeconds(_timeBetweenWaves);

            _spawnedEnemiesCount = 0;
            _currentWaveNumber++;
            SetWave(_currentWaveNumber);
        }
    
        private void SetEnemy(EnemyAttacker enemyCloseAttacker)
        {
            var spawnPointNumber = Random.Range(0, _spawnPoints.Length);
        
            enemyCloseAttacker.transform.position = _spawnPoints[spawnPointNumber].position;
            enemyCloseAttacker.transform.LookAt(_player);
            enemyCloseAttacker.gameObject.SetActive(true);
            enemyCloseAttacker.transform.SetParent(null);
            enemyCloseAttacker.Init(_player);

            if (enemyCloseAttacker.TryGetComponent(out EnemyHealth enemyHealth))
                enemyHealth.ResetValues();
            else
                throw new ArgumentNullException();
        }

        private void SetWave(int waveNumber)
        {
            if (waveNumber >= 0 && waveNumber < _waves.Count)
                CurrentWave = _waves[waveNumber];
        }
    }

    [Serializable]
    public class Wave
    {
        [SerializeField] private EnemyAttacker _enemyAttacker;
        [SerializeField] private int _enemiesCount;
        [SerializeField] private float _delay;

        public EnemyAttacker EnemyAttacker => _enemyAttacker;
        public int EnemiesCount => _enemiesCount;
        public float Delay => _delay;
    }
}