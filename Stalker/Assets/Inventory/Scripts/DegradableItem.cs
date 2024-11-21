using System.Collections;
using System.Collections.Generic;
using RainGayming.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.Inventory
{
    public class DegradableItem : ItemObject
    {
        [BoxGroup("Degredation Information")]
        public float maxDegradation;
    }
}