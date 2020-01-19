using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parameters that can be shared throughout all InputStates -- NOT THE INPUT(S) ACTUALLY 
/// </summary>
public class InputParameters
{
    public struct InputCommands
    {
        public Rune rune1;
        public Rune rune2;
    }

    public List<Vector3> VectorInput = new List<Vector3>();
    public List<iSelectableUnit> UnitInput = new List<iSelectableUnit>();
    public SpellInstance SpellInstance;
    public iSelectableUnit Caster;

    public Delivery DeliveryInput => SpellInstance.Delivery;

    public InputCommands Commands = new InputCommands();

    public InputParameters()
    {
        ClearParameters();
    }

    //  TODO should be getting cleared in PlayerInput!!
    public void ClearParameters()
    {
        VectorInput.Clear();
        UnitInput.Clear();
        SpellInstance = null;
    }
}
