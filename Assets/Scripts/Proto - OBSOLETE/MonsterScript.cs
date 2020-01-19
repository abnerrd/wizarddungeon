using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PROTOTYPE
{
    public class MonsterScript : KillableUnit
    {
        protected override void OnDeath()
        {
            Destroy(this.gameObject);
        }
    }
}