using System.Collections;
using Enemy;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CapsuleCollider))]
    public sealed class PlayerDeadZone : MonoBehaviour
    {
        private const float MinDelay = 0.1f;
        
        [SerializeField] private int _damage;
        [SerializeField] private float _delay;
        [SerializeField] private int _addingDamage;
        [SerializeField] private float _reducingDelay;

        private CapsuleCollider _capsuleCollider;
        private bool _canAttack  = true;

        private void Awake()
        {
            _capsuleCollider = GetComponent<CapsuleCollider>();
        }

        private void Start()
        {
            gameObject.SetActive(false);

            _capsuleCollider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out EnemyHealth enemyHealth) && enemyHealth.IsDied == false && _canAttack)
            {
                enemyHealth.TryTakeDamage(_damage);

                _canAttack = false;
                StartCoroutine(WaitTimeBetweenAttacks());
            }
        }

        public void IncreaseDamage(int level)
        {
            _damage += _addingDamage * level;
        }

        public void ReduceDelay()
        {
            _delay -= _reducingDelay;

            if (_delay <= 0)
                _delay = MinDelay;
        }

        private IEnumerator WaitTimeBetweenAttacks()
        {
            yield return new WaitForSeconds(_delay);
            _canAttack = true;
        }
    }
}