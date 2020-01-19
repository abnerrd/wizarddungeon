using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState : InputState
{
    //  TODO database prefabs
    private const string DirectoryPath = "Prefabs/Delivery";

    public override iInputState HandleInput(InputParameters parameters)
    {
        switch (parameters.DeliveryInput)
        {
            case Delivery.Direction:
                {
                    SpawnProjectile(parameters);
                    break;
                }

            case Delivery.Unit:
                {
                    SpawnBuff(parameters);
                    break;
                }

            case Delivery.Location:
                {

                    break;
                }

            case Delivery.Invalid:
                {
                    Debug.LogWarning("Invalid delivery");
                    break;
                }
        }

        return new IdleState();
    }

    //
    private void SpawnProjectile(InputParameters parameters)
    {
        //  Create Projectile Object and assign spell 
        var projectilePrefab = Resources.Load($"{DirectoryPath}/projectile");
        var projectileObject = Object.Instantiate(projectilePrefab) as GameObject;
        var spellDelivery = projectileObject.GetComponent<ProjectileDelivery>();
        spellDelivery.assignSpell(parameters.Caster, parameters.SpellInstance);

        //  Point in direction to travel
        if (parameters.VectorInput.Count <= 0) 
        {
            Debug.LogError("Not enough information to dicern direction.");
            return;
        }
        var direction = parameters.VectorInput[0] - parameters.Caster.GetPosition();
        spellDelivery.setDirection(direction);

        //  Originate at caster
        spellDelivery.transform.position = parameters.Caster.GetPosition();


        spellDelivery.fire();
        Debug.Log("pechew!");
    }

    private void SpawnBuff(InputParameters parameters)
    {
        if(parameters.UnitInput.Count <= 0)
        {
            return;
        }

        var unitTarget = parameters.UnitInput[0];
        var spell = unitTarget.AddBuff(parameters);
        spell.fire();
        Debug.Log("pe-buff!");
    }
}
