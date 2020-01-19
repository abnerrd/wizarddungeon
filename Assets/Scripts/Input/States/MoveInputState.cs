using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInputState : CancellableState
{
    public override iInputState HandleInput(InputParameters parameters)
    {
        if (Input.GetMouseButtonDown(0))
        {
            var clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //  hardcoded plane position
            clickPosition.y = -2.5f;
            Debug.Log($"Moving to {clickPosition}");

            var selectedUnits = parameters.UnitInput;
            for (int i = 0; i < selectedUnits.Count; ++i)
            {
                selectedUnits[i].SetDestination(clickPosition);
            }

            //  TODO i don't like that the state is responsible for ClearParameters... could the return be a packet w/ flags on what to do, etc.?
            parameters.ClearParameters();

            return new IdleState();
        }

        return base.HandleInput(parameters);
    }
}
