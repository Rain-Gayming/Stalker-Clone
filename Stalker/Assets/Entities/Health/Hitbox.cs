using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.Health
{
    public class Hitbox : MonoBehaviour
    {
        [BoxGroup("Hitbox Info")]
        public Limb limb;
        [BoxGroup("Hitbox Info")]
        public float health;
        [BoxGroup("Hitbox Info")]
        public float maxHealth;
        [BoxGroup("Hitbox Info")]
        public bool isBroken;
    }
}