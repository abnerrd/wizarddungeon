using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Utility class to help w/ selecting of Spells.
/// Refrain from doing Spell logic here.
/// </summary>
public static class SpellbookUtil
{
    public static SpellInstance CreateSpell(List<Rune> selectedRunes)
    {
        if(selectedRunes.Count <= 0)
        {
            Debug.LogWarning("SpellbookUtil: selected Runes list is empty.");
            return null;
        }

        var newSpell = new SpellInstance();
        var spellParts = new List<iSpellPart>();

        switch (selectedRunes.Count)
        {
            case 1:
                {
                    spellParts = ExtractSpellParts(selectedRunes[0]);
                    newSpell.SetRunes(selectedRunes[0]);
                    break;
                }
            case 2:
                {
                    spellParts = ExtractSpellParts(selectedRunes[0], selectedRunes[1]);
                    newSpell.SetRunes(selectedRunes[0], selectedRunes[1]);
                    break;
                }
            default:
                {
                    Debug.LogError("Incorrect number of Runes provided to selected SpellParts!");
                    break;
                }
        }

        if(spellParts == null || spellParts.Count <= 0)
        {
            Debug.LogError("No SpellParts collected.");
            return null;
        }

        newSpell.SetSpellParts(spellParts);
        return newSpell;
    }

    private static List<iSpellPart> ExtractSpellParts(Rune primary)
    {
        if (primary == null)
        {
            Debug.LogError($"Null Rune detected: P:{primary}");
            return null;
        }

        var collectedParts = new List<iSpellPart>();
        collectedParts.AddRange(primary.PrimarySpellEffects);
        return collectedParts;
    }

    private static List<iSpellPart> ExtractSpellParts(Rune primary, Rune secondary)
    {
        if(primary == null || secondary == null)
        {
            Debug.LogError($"Null Rune(s) detected: P:{primary}, S:{secondary}");
            return null;
        }

        var collectedParts = new List<iSpellPart>();
        collectedParts.AddRange(primary.PrimarySpellEffects);
        collectedParts.AddRange(secondary.SecondarySpellEffects);
        return collectedParts;
    }
}
