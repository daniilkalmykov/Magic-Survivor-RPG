using Player;
using UnityEngine;

namespace Infrastructure
{
    public sealed class ExperienceCube : MonoBehaviour
    {
        [SerializeField] private int _chanceToCreate;
        [SerializeField] private int _experience;
        
        public int ChanceToCreate => _chanceToCreate;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerExperience playerExperience))
            {
                playerExperience.AddExperience(_experience);
                Destroy(gameObject);
            }
        }
    }
}