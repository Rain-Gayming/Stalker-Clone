using System.Collections;
using System.Collections.Generic;
using RainGayming.Combat;
using RainGayming.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.Health
{
    public class Hitbox : MonoBehaviour
    {

        [BoxGroup("Hitbox Info")]
        public HealthManager healthManager;
        [BoxGroup("Hitbox Info")]
        public Limb limb; public bool isBroken;

        private void Start()
        {
            healthManager = GetComponentInParent<HealthManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<BulletObject>())
            {
                healthManager.ChangeHealth(true, other.GetComponent<BulletObject>().bulletInfo.fleshDamage, limb);

                print(name + " was hit by " + other.name);
            }
        }
    }
}