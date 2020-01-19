using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  TODO use to make States more abstract

/*[Serializable]
public struct TransitionPair
{
    [SerializeField]
    public iInputKey Input;
    [SerializeField]
    public iInputState State;
}*/

public abstract class InputState : iInputState
{
    public InputState()
    {
    }

    public abstract iInputState HandleInput(InputParameters parameters);
}

/// <summary>
/// Inheritance from this class allows the State to be cancelled
/// </summary>
public class CancellableState : InputState
{
    public override iInputState HandleInput(InputParameters parameters)
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Cancelling current state!");
            parameters.ClearParameters();
            return new IdleState();
        }

        return this;
    }
}
