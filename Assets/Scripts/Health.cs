using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;

    public event Action Died;
    
    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
              Die();          
    }

    protected virtual void Die()
    {
        Died?.Invoke();
        gameObject.SetActive(false);
    }
}
