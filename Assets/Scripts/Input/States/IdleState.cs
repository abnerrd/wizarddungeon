using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : InputState
{
    public IdleState()
    {
    }

    public override iInputState HandleInput(InputParameters parameters)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            return new ChannelingState();
        }

        if (Input.GetMouseButtonDown(0))
        {
            //  Starting mouse position
            parameters.VectorInput.Add(Input.mousePosition);
            return new SelectingBoundsState();
        }

        return this;
    }
}
