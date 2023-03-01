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
            {
                var position = transform.position;
                const float YPosition = 1;
                Instantiate(cube, new Vector3(position.x, YPosition, position.z), Quaternion.identity, null);
            }
        }
    }
}