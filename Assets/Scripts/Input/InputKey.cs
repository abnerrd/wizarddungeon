using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iInputKey
{
    bool IsTriggered();
}

[Serializable]
public struct KeyInputKey : iInputKey
{
    [SerializeField]
    public KeyCode KeyboardInput;

    public bool IsTriggered()
    {
        return Input.GetKey(KeyboardInput);
    }
}

[Serializable]
public struct MouseInputKey : iInputKey
{ 
    public enum MouseInput
    {
        Invalid= -1,
        Mouse1 = 0,
        Mouse2
    }
    [SerializeField]
    public MouseInput MouseButtonInput;

    public bool IsTriggered()
    {
        switch (MouseButtonInput)
        {
            case MouseInput.Mouse1:
            case MouseInput.Mouse2:
                {
                    return Input.GetMouseButtonDown((int)MouseButtonInput);
                }

            default:
                {
                    return false;
                }
        }
    }
}