using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRune", menuName = "Magic/New Rune")]
public class Rune : ScriptableObject
{
    public ElementalAttributes RuneAttribute;
    public Statistic RuneStatistic;

    //  TODO possible room for SOLO COMPONENTS

    [Header("Primary Components")]
    public SpellProperties PrimaryProperty;
    public List<SpellEffect> PrimarySpellEffects;

    [Header("Secondary Components")]
    public SpellProperties SecondaryProperty;
    public List<SpellEffect> SecondarySpellEffects;
}
