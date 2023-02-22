using System.Security.Cryptography;
using Enemy;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    
    private Transform _target;

    private void Update()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out EnemyHealth enemyHealth))
            enemyHealth.TakeDamage(_damage);
        
        Destroy(gameObject);
    }

    public void Init(Transform target)
    {
        _target = target;
    }
}