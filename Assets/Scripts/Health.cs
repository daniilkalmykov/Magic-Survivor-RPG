using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Health : MonoBehaviour
{
    [SerializeField] private AnimationClip _dieAnimationClip;
    [SerializeField] private float _maxHealth;

    private Animator _animator;
    private float _currentHealth;
    
    public event Action Died;
    
    public bool IsDied { get; private set; }

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    protected virtual void OnEnable()
    {
        IsDied = false;
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
        
        if(_currentHealth > 0)
            _animator.SetTrigger(AnimatorStates.Hit);
        else
        {
            _animator.Play(_dieAnimationClip.name);
            IsDied = true;
            
            StartCoroutine(DieCoroutine());
        }
    }

    protected virtual void Die()
    {
        Died?.Invoke();
        gameObject.SetActive(false);
    }

    protected virtual IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(_dieAnimationClip.length);
        Die();
    }
}
