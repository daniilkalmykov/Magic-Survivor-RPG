using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public abstract class AttackingTrigger : MonoBehaviour
{
    private CapsuleCollider _capsuleCollider;
    
    public bool IsOpponentInTrigger { get; private set; }

    private void Awake()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public void Init(float radius)
    {
        _capsuleCollider.radius = radius;
    }

    protected void OnDied()
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

    protected abstract void OnTriggerEnter(Collider other);
    protected abstract void OnTriggerExit(Collider other);
}