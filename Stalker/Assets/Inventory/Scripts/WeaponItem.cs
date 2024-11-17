using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RainGayming.Inventory
{
    public class WeaponItem : DegradableItem
    {
        [Header("Weapon Info")]
        public float baseDamage;
        public float attackTime;
    }
}