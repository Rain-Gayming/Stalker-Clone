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
        [BoxGroup("Gun Info")]
        public bool hasChamber;
        [BoxGroup("Gun Info")]
        public int baseMagSize;
        [BoxGroup("Gun Info")]
        public float reloadTime = 1.5f;

        [BoxGroup("Gun Animations")]
        public string animationName;

        public override void SetDescription()
        {
            base.SetDescription();

            generatedDescription = "velocity: " + baseVelocity;
        }
    }
}