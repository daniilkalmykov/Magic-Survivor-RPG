using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    private float _currentHealth;
    private Animator _animator;
    
    public event Action Died;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        ResetValues();
    }

    public void ResetValues()
    {
        _currentHealth = _maxHealth;
    }
    
    public void TryTakeDamage(float damage)
    {
        if(damage <= 0)
            return;
        
        _currentHealth -= damage;

        if (_currentHealth <= 0)
              Die();      
        
        _animator.SetTrigger(AnimatorStates.Hit);
    }

    protected virtual void Die()
    {
        Died?.Invoke();
        gameObject.SetActive(false);
    }
}
