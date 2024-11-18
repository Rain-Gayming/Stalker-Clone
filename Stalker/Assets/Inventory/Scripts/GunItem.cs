using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace RainGayming.Inventory
{
    [CreateAssetMenu(menuName = "Inventory/Gun")]
    public class GunItem : WeaponItem
    {
        [Header("Gun Info")]
        public float baseVelocity;
        public List<FireMode> fireModes;
    }
}