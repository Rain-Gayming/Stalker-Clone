using System.Collections;
using System.Collections.Generic;
using RainGayming.Inputs;
using RainGayming.Inventory;
using UnityEngine;


namespace RainGayming.Combat
{
    public class RangedWM : WeaponManager
    {
        [Header("References")]
        public InputManager inputs;

        [Header("Gun Info")]
        public GunItem gunInfo;
        public float fireTime;
        public FireMode currentFireMode;
        public FireMode lastFireMode;
        public bool canShoot;

        [Header("Bullets")]
        public int currentAmmo;
        public Transform muzzleLocation;
        public BulletItem currentBullet;

        private void Start()
        {
            inputs = InputManager.instance;
        }

        private void Update()
        {
            fireTime -= Time.deltaTime;

            if (!canShoot && fireTime <= 0 && !InputManager.instance.attackInput)
            {
                canShoot = true;
                print("Can Shoot");
            }
        }

        public void FireModeSwitch()
        {
            lastFireMode = currentFireMode;

            if(gunInfo.fireModes.Contains(lastFireMode + 1)){
                print("yippe");
            }
        }

        public void Reload()
        {

        }

        public override void Attack()
        {
            if (fireTime <= 0 && currentAmmo > 0 && canShoot)
            {
                switch (currentFireMode)
                {
                    case FireMode.semi:
                        Shoot();
                        canShoot = false;
                        break;

                    case FireMode.auto:
                        Shoot();
                        break;
                }
            }
        }

        public void Shoot()
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