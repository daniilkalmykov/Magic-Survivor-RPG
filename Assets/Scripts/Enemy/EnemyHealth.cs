using UnityEngine;

namespace Enemy
{
    public sealed class EnemyHealth : Health
    {
        [SerializeField] private ExperienceCube[] _experienceCubes;
        
        protected override void Die()
        {
            base.Die();
            CreateExperienceCube();
        }

        private void CreateExperienceCube()
        {
            const int MinRandomChance = 0;
            const int MaxRandomChance = 100;
            
            var randomExperienceCubeNumber = Random.Range(0, _experienceCubes.Length);
            var randomChance = Random.Range(MinRandomChance, MaxRandomChance);
            
            var cube = _experienceCubes[randomExperienceCubeNumber];

            if (randomChance > cube.ChanceToCreate)
                Instantiate(cube, transform.position, Quaternion.identity, null);
        }
    }
}