using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace RainGayming.Inventory
{
    [CreateAssetMenu(menuName = "Inventory/Gun")]
    public class GunItem : WeaponItem
    {
        [BoxGroup("Gun Info")]
        public float baseVelocity;
        [BoxGroup("Gun Info")]
        public List<FireMode> fireModes;

        public override void SetDescription()
        {
            base.SetDescription();

            generatedDescription = "velocity: " + baseVelocity;
        }
    }
}