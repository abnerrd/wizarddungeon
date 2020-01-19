using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Instance of real-life Spell
/// </summary>
public class SpellInstance
{
    private Rune _primary;
    private Rune _secondary;

    public Delivery Delivery { get; private set; }

    public List<iSpellPart> SpellParts;

    public void Apply(Unit unit)
    {
        var effectParts = SpellParts.Select(p => (SpellEffect)p).ToList();
        foreach(var effect in effectParts)
        {
            effect.Apply(unit);
        }
    }

    public void SetRunes(Rune primaryRune, Rune secondaryRune = null)
    {
        _primary = primaryRune;
        Delivery = _primary.PrimaryProperty.Delivery;

        _secondary = secondaryRune;
        if(_secondary != null && _secondary.SecondaryProperty.Delivery != Delivery.Invalid)
        {
            Delivery = _secondary.SecondaryProperty.Delivery;
        }
    }

    public void SetSpellParts(List<iSpellPart> parts)
    {
        SpellParts = new List<iSpellPart>(parts);
    }
}
