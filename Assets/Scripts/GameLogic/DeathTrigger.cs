using Enemy;
using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(BoxCollider))]    
    public class DeathTrigger : MonoBehaviour
    {
        private BoxCollider _boxCollider;

        private void Awake()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }

        private void Start()
        {
            _boxCollider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyHealth enemyHealth))
                enemyHealth.TryTakeDamage(enemyHealth.MaxHealth);
        }
    }
}
