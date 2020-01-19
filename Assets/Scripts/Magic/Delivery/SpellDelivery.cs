using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Base class for Delivery spells. 
 * Handles basic lifetime logic for all Spells.
 */
public abstract class SpellDelivery : MonoBehaviour, iDelivery
{
    public enum State
    {
        Standby,
        Fired,
        Done
    }

    protected SpellInstance _spellInfo;
    protected iSelectableUnit _caster;

    protected State _currentState;

    protected List<iSelectableUnit> _immunityList = new List<iSelectableUnit>();
    public abstract void updateDelivery();

    public void assignSpell(iSelectableUnit caster, SpellInstance spell)
    {
        _spellInfo = spell;
        _caster = caster;

        _immunityList.Add(caster);
    }

    public void fire()
    {
        _currentState = State.Fired;
    }

    protected void destroy() 
    {
        _currentState = State.Done;
        this.enabled = false;
    }

    private void Update()
    {
        updateDelivery();

        //  TODO disable when lifetime ends
    }
}
