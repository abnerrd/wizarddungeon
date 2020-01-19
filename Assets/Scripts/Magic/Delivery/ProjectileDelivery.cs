using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ProjectileDelivery : SpellDelivery
{
    private Vector2 _direction;
    private Rigidbody _rigidbody;

    [SerializeField]
    private float _projectileSpeed = 1f;

    private void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        onImpact(collision.collider.GetComponent<Unit>());
    }

    public void setDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public override void updateDelivery()
    {
        if(_currentState == State.Fired)
        {
            _rigidbody.velocity = _direction * _projectileSpeed;
        }
    }

    private void onImpact(Unit victim)
    {
        if(victim == null || _immunityList.Contains(victim))
        {
            return;
        }

        _spellInfo.Apply(victim);
        destroy();
    }
}
