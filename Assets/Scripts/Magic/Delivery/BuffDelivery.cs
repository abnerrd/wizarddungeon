using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDelivery : SpellDelivery
{
    public override void updateDelivery()
    {
        if(_currentState == State.Fired)
        {
            _spellInfo.Apply(this.GetComponent<Unit>());
            destroy();
        }
    }
}
