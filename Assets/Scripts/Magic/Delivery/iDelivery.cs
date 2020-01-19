using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface iDelivery
{
    void assignSpell(iSelectableUnit caster, SpellInstance spell);
    void fire();
    void updateDelivery();
}
