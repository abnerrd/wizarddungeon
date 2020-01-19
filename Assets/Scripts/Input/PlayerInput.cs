using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private bool _isSelecting = false;

    private Vector3 _startScreenPosition;

    [SerializeField]
    private List<iSelectableUnit> _selectedUnits;

    private InputState _state;
    private InputParameters _parameters;

    [SerializeField]
    private Rune _rune1;
    [SerializeField]
    private Rune _rune2;

    private void Awake()
    {
        _selectedUnits = new List<iSelectableUnit>();
        _parameters = new InputParameters();
        _parameters.Caster = this.GetComponent<iSelectableUnit>();
        _parameters.Commands.rune1 = _rune1;
        _parameters.Commands.rune2 = _rune2;

        _state = new IdleState();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInputState();
    }

    public void UpdateInputState()
    {
        var newState = (InputState)_state.HandleInput(_parameters);
        if(newState != null && newState != _state)
        {
            //  TODO Exit _state

            _state = newState;

            //  TODO enter _state
        }
    }
}
