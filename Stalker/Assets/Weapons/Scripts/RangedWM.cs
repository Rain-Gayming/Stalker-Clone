using System.Collections;
using System.Collections.Generic;
using RainGayming.Inventory;
using UnityEngine;


namespace RainGayming.Combat
{
    public class RangedWM : WeaponManager
    {
        [Header("Gun Info")]
        public GunItem gunInfo;
        public float fireTime;

        [Header("Bullets")]
        public int currentAmmo;
        public Transform muzzleLocation;
        public BulletItem currentBullet;

        private void Update()
        {
            fireTime -= Time.deltaTime;
        }

        public void Reload()
        {

        }

        public override void Attack()
        {
            if (fireTime <= 0 && currentAmmo > 0)
            {
                GameObject newBullet = Instantiate(currentBullet.bulletObject);
                newBullet.GetComponent<BulletObject>().gunInfo = gunInfo;
                newBullet.transform.position = muzzleLocation.transform.position;
                newBullet.transform.rotation = muzzleLocation.transform.rotation;

                currentAmmo--;
                fireTime = gunInfo.attackTime;
            }
        }
    }

}