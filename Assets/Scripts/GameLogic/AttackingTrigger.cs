using System;
using UnityEngine;

namespace GameLogic
{
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

        public void SetStartRadius()
        {
            _capsuleCollider.radius = 0;
        }

        public void SetInitRadius()
        {
            _capsuleCollider.radius = _radius;
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
}