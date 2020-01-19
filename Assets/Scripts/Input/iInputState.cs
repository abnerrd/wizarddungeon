using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iInputState
{
    /// <summary>
    /// parameters are pass-by-ref
    /// </summary>
    /// <param name="parameters"></param>
    iInputState HandleInput(InputParameters parameters);
}