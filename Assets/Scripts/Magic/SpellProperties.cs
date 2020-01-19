using System;
using UnityEngine;

/// <summary>
/// Generic definitions and variables of a Spell
/// </summary>
[Serializable]
public struct SpellProperties : iSpellPart
{
    [Header("Base Properties")]
    public ElementalAttributes Attribute;

    public Delivery Delivery;

    public Statistic AttributeStatistic;

    [Header("Spawn Variables")]
    /// <summary>
    /// Defines how many times the Spell should fire 
    /// </summary>
    [Tooltip("Defines how many times the Spell should fire")]
    [Min(1)]
    public int ActivateCount; // = 3

    /// <summary>
    /// Defines how many instances of Delivery this will Spawn when activated
    /// </summary>
    [Tooltip("Defines how many instances of Delivery this will Spawn when activated")]
    [Min(1)]
    public int SpawnAmount; // = 1

    /// <summary>
    /// Defines if there is a delay between each ActivateCount
    /// </summary>
    [Tooltip("Defines if there is a delay between each ActivateCount")]
    [Min(0.0f)]
    public float SpawnDelay;  //  = 0.5s
}
