using UnityEngine;

//  like knockback and shizz
[CreateAssetMenu(fileName = "NewManipulateUnitEffect", menuName = "Magic/Effect/New ManipulateUnit Effect")]
public class ManipulateUnitEffect : SpellEffect
{
    //  Can the Unit still move around while affected?
    //  public bool RetainMovementAbility

    //  public bool ResetVelocityAfter

    public override void Apply(Unit target)
    {
        throw new System.NotImplementedException();

        //  TODO same as ModifyStat, define enum Manipulations that can be done -- can be done enum-specifically, or constructed w/ V3 and certain directions
    }
}
