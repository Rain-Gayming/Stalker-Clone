using System.Collections;
using System.Collections.Generic;
using RainGayming.Inputs;
using RainGayming.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;


namespace RainGayming.Combat
{
    public class RangedWM : WeaponManager
    {
        [BoxGroup("References")]
        public InputManager inputs;

        [BoxGroup("Gun Info")]
        public GunItem gunInfo;
        [BoxGroup("Gun Info")]
        public float fireTime;
        [BoxGroup("Gun Info")]
        public FireMode currentFireMode;
        [BoxGroup("Gun Info")]
        public FireMode lastFireMode;
        [BoxGroup("Gun Info")]
        public bool canShoot;
        [BoxGroup("Gun Info")]
        public bool isReloading;

        [BoxGroup("Bullets")]
        public int currentAmmo;
        [BoxGroup("Bullets")]
        public Transform muzzleLocation;
        [BoxGroup("Bullets")]
        public BulletItem currentBullet;

        private void Start()
        {
            inputs = InputManager.instance;
            weaponInfo = gunInfo;
        }

        private void Update()
        {
            fireTime -= Time.deltaTime;

            if (!canShoot && fireTime <= 0 && !InputManager.instance.attackInput)
            {
                canShoot = true;
                print("Can Shoot");
            }

            if (inputs.reloadInput)
            {
                inputs.reloadInput = false;
                Reload();
            }
        }

        public void FireModeSwitch()
        {
            lastFireMode = currentFireMode;

            if (gunInfo.fireModes.Contains(lastFireMode + 1))
            {
                print("yippe");
            }
        }

        public void Reload()
        {
            StartCoroutine(ReloadCo());
        }

        public IEnumerator ReloadCo()
        {
            //do reload animation
            isReloading = true;
            yield return new WaitForSeconds(gunInfo.reloadTime);
            //stop reload animation

            //if you already have a bullet in your chamber add it to the ammo pool
            if (currentAmmo != 0)
            {
                currentAmmo = gunInfo.baseMagSize;
            }
            else if (gunInfo.hasChamber)
            {
                currentAmmo = gunInfo.baseMagSize + 1;
            }

            isReloading = true;
        }

        public override void Attack()
        {
            if (fireTime <= 0 && currentAmmo > 0 && canShoot && !isReloading)
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