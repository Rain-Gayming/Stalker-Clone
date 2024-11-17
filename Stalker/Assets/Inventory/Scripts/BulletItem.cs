using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace RainGayming.Inventory
{
    [CreateAssetMenu(menuName = "Inventory/Bullet")]
    public class BulletItem : WeaponItem
    {
        [Header("Bullet Info")]
        public int fleshDamage;
        public int piercing;
        public GameObject bulletObject;
    }
}