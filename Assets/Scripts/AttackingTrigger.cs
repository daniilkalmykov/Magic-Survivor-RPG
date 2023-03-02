using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public abstract class AttackingTrigger : MonoBehaviour
{
    private CapsuleCollider _capsuleCollider;
    private float _radius;
    
    public bool IsOpponentInTrigger { get; private set; }

    private void Awake()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public void Init(float radius)
    {
        if (radius <= 0)
            throw new ArgumentNullException(); 
        
        _radius = radius;
        _capsuleCollider.radius = radius;
    }

    protected virtual void OnDied()
    {
        IsOpponentInTrigger = false;
    }
    
    protected void SwitchOpponentStateToTrue()
    {
        IsOpponentInTrigger = true;
    }

    protected void SwitchOpponentStateToFalse()
    {
        IsOpponentInTrigger = false;
    }

    protected void SetStartRadius()
    {
        _capsuleCollider.radius = 0;
    }

    protected void SetInitRadius()
    {
        _capsuleCollider.radius = _radius;
    }

    protected abstract void OnTriggerEnter(Collider other);
    protected abstract void OnTriggerExit(Collider other);
}