using UnityEngine;

/// <summary>
/// Special actions that Spells execute.
/// </summary>
public abstract class SpellEffect : ScriptableObject, iSpellPart
{
    public abstract void Apply(Unit target);
    //  TODO void Apply(Object receiver); // as if Spells would affect props in environment
}