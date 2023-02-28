﻿using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    private const float TargetYPosition = 1.5f;
    
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;
    
    private Transform _target;

    protected float Damage => _damage;
    
    private void Update()
    {
        if(_target.gameObject.activeSelf == false || _target == null)
            Destroy(gameObject);

        var position = _target.position;
        var targetPosition = new Vector3(position.x, TargetYPosition, position.z);
        transform.position =
            Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    public void Init(Transform target)
    {
        _target = target;
    }
}