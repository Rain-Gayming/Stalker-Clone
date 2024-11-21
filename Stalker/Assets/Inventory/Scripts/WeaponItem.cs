using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.Inventory
{
    public class WeaponItem : DegradableItem
    {
        [BoxGroup("Weapon Info")]
        public float baseDamage;
        [BoxGroup("Weapon Info")]
        public float attackTime;
    }
}