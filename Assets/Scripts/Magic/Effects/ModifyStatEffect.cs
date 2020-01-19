using System;
using UnityEngine;

/// <summary>
/// Modify that Stat of a Unit
/// </summary>
[Serializable]
[CreateAssetMenu(fileName = "NewModifyStatEffect", menuName = "Magic/Effect/New ModStat Effect")]
public class ModifyStatEffect : SpellEffect 
{
    private enum ModifyExecution
    {
        Set,
        AddTo,
        SubtractFrom
    }
    
    [Header("Base Modification")]
    [SerializeField]
    private ModifyExecution Execution;

    [SerializeField]
    private Statistic StatToModify;

    [Header("Bonuses")]
    [Tooltip("What stat empowers the ModifyValue")]
    public Statistic StatMultiplier;

    public override void Apply(Unit target)
    {
        switch (StatToModify)
        {
            case Statistic.Health:
                {
                    ModifyHealth(target, Execution);
                    break;
                }

            default:
                {
                    throw new System.NotImplementedException();
                }
        }
    }

    private void ModifyHealth(Unit target, ModifyExecution execution)
    {
        //  TODO get values from SPELLS + CASTER

        switch (execution)
        {
            case ModifyExecution.SubtractFrom:
                {
                    target.ReceiveDamage(15);
                    break;
                }

            case ModifyExecution.AddTo:
                {
                    target.ReceiveHealing(15);
                    break;
                }

            default:
                {
                    throw new System.NotImplementedException();
                }
        }
    }
}
