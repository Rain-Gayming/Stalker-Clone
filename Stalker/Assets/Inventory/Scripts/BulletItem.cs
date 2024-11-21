using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.Inventory
{
    [CreateAssetMenu(menuName = "Inventory/Bullet")]
    public class BulletItem : ItemObject
    {
        [BoxGroup("Bullet Info")]
        public int fleshDamage;
        [BoxGroup("Bullet Info")]
        public int piercing;
        [BoxGroup("Bullet Info")]
        public GameObject bulletObject;

        public override void SetDescription()
        {
            base.SetDescription();

            generatedDescription = "flesh damage: " + fleshDamage + " \narmour penetration " + piercing;
        }
    }
}