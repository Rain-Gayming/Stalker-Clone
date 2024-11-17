using System.Collections;
using System.Collections.Generic;
using RainGayming.Inventory;
using UnityEngine;


namespace RainGayming.Combat
{
    public class RangedWM : WeaponManager
    {

        [Header("Bullets")]
        public int currentAmmo;
        public Transform muzzleLocation;
        public BulletItem currentBullet;

        public void Reload()
        {

        }

        public override void Attack()
        {
            base.Attack();
        }
    }

}