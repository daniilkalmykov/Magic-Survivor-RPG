﻿using System;
using System.Collections;
using Constants;
using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(Animator), typeof(AudioSource))]
    public abstract class Health : MonoBehaviour
    {
        [SerializeField] private AnimationClip _dieAnimationClip;
        [SerializeField] private ParticleSystem _hit;
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _addingHealthValue;
        [SerializeField] private AudioSource _healingSound;

        private Animator _animator;
        private AudioSource _audioSource;
        private int _currentHealth;
        private bool _hasHitSound;

        public event Action<int, int> Changed;
        public event Action Died;
    
        public bool IsDied { get; private set; }
        public int MaxHealth => _maxHealth;

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
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
            Changed?.Invoke(_currentHealth, MaxHealth);
        }
    
        public void TryTakeDamage(int damage)
        {
            if(damage <= 0)
                return;
        
            _currentHealth -= damage;
            Instantiate(_hit, transform.position, Quaternion.identity, transform);

            if (_currentHealth > 0)
            {
                _animator.SetTrigger(AnimatorStates.Hit);
            }
            else
            {
                IsDied = true;
                _animator.Play(_dieAnimationClip.name);
            
                StartCoroutine(DieCoroutine());
            }
            
            _audioSource.Play();
            
            Changed?.Invoke(_currentHealth, _maxHealth);
        }

        public void Increase()
        {
            _maxHealth += _addingHealthValue;
            ResetValues();
        }

        public void Increase(int level)
        {
            _maxHealth += _addingHealthValue * level;
            ResetValues();
            _healingSound.Play();
        }

        public void TryIncrease(int value)
        {
            if (value <= 0)
                throw new ArgumentNullException();

            _maxHealth += value;
            ResetValues();
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
}
