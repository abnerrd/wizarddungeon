using System;
using UnityEngine;

[Obsolete("REPLACED BY iSPELLPARTS", true)]
[Serializable]
[CreateAssetMenu(fileName = "NewSpellInstructions", menuName = "Magic/Instructions")]
public class SpellInstructions : ScriptableObject
{
    public Delivery Delivery;

    public SpellEffect Effect;

    [SerializeField]
    public int CastRange;

    [SerializeField]
    public float Lifetime;
}
