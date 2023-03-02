using System.Collections;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyAttacker), typeof(EnemyMovement))]
    public sealed class EnemyHealth : Health
    {
        [SerializeField] private ExperienceCube[] _experienceCubes;

        private EnemyAttacker _enemyAttacker;
        private EnemyMovement _enemyMovement;

        protected override void Awake()
        {
            base.Awake();

            _enemyAttacker = GetComponent<EnemyAttacker>();
            _enemyMovement = GetComponent<EnemyMovement>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            _enemyAttacker.enabled = true;
            _enemyMovement.enabled = true;
        }

        protected override void Die()
        {
            base.Die();
            CreateExperienceCube();
        }

        protected override IEnumerator DieCoroutine()
        {
            _enemyAttacker.enabled = false;
            _enemyMovement.enabled = false;
            return base.DieCoroutine();
        }

        private void CreateExperienceCube()
        {
            const int MinRandomChance = 0;
            const int MaxRandomChance = 100;
            
            var randomExperienceCubeNumber = Random.Range(0, _experienceCubes.Length);
            var randomChance = Random.Range(MinRandomChance, MaxRandomChance);
            
            var cube = _experienceCubes[randomExperienceCubeNumber];

            if (randomChance > cube.ChanceToCreate)
            {
                var position = transform.position;
                const float YPosition = 1;
                Instantiate(cube, new Vector3(position.x, YPosition, position.z), Quaternion.identity, null);
            }
        }
    }
}