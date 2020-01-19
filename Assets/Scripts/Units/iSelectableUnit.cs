using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iSelectableUnit
{
    void SetDestination(Vector3 destination);
    Vector3 GetPosition();
    BuffDelivery AddBuff(InputParameters spell);
}
