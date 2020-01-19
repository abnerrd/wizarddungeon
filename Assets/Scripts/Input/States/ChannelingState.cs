using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelingState : CancellableState
{
    private List<Rune> _selectedRunes;

    public ChannelingState()
    {
        _selectedRunes = new List<Rune>();
    }

    public override iInputState HandleInput(InputParameters parameters)
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            var createdSpell = SpellbookUtil.CreateSpell(_selectedRunes);
            if(createdSpell != null)
            {
                parameters.SpellInstance = createdSpell;

                return new DeliveryInputState();
            }
            else
            {
                return new IdleState();
            }
        }

        HandleSpellSelection(parameters.Commands);
        return base.HandleInput(parameters);
    }

    private void HandleSpellSelection(InputParameters.InputCommands spellCommands)
    {
        if (!Input.anyKeyDown)
        {
            return;
        }

        //  TODO would be nice to simplify selection to delegated commands
        if (Input.GetKeyDown(KeyCode.A))
        {
            _selectedRunes.Add(spellCommands.rune1);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _selectedRunes.Add(spellCommands.rune2);
        }
    }
}
