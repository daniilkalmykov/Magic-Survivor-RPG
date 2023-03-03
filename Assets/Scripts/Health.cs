using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Health : MonoBehaviour
{
    [SerializeField] private AnimationClip _dieAnimationClip;
    [SerializeField] private int _maxHealth;

    private Animator _animator;

    public event Action Died;
    
    public bool IsDied { get; private set; }
    public int MaxHealth => _maxHealth;
    public int CurrentHealth { get; private set; }

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

    public virtual void ResetValues()
    {
        CurrentHealth = _maxHealth;
    }
    
    public virtual void TryTakeDamage(int damage)
    {
        if(damage <= 0)
            return;
        
        CurrentHealth -= damage;
        
        if(CurrentHealth > 0)
            _animator.SetTrigger(AnimatorStates.Hit);
        else
        {
            IsDied = true;
            _animator.Play(_dieAnimationClip.name);
            
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
