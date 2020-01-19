using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AOEDelivery : SpellDelivery
{
    private List<Unit> _victims = new List<Unit>();

    public override void updateDelivery()
    {
        lock (_victims)
        {
            foreach(var unit in _victims)
            {
                _spellInfo.Apply(unit);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        addVictim(collision.GetComponent<Unit>());
    }

    private void OnTriggerExit(Collider collision)
    {
        removeVictim(collision.GetComponent<Unit>());
    }

    private void addVictim(Unit victim)
    {
        if(victim == null)
        {
            return;
        }

        if (!_victims.Contains(victim))
        {
            _victims.Add(victim);
        }
    }

    private void removeVictim(Unit victim)
    {
        if (victim == null)
        {
            return;
        }

        _victims.Remove(victim);
    }
}
