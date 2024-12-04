using System.Collections;
using System.Collections.Generic;
using RainGayming.Combat;
using RainGayming.Game;
using RainGayming.Inputs;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace RainGayming.Combat
{
    public class PlayerWM : MonoBehaviour
    {
        public static PlayerWM instance;
        public bool isPaused;
        [BoxGroup("Reference")]
        public InputManager inputs;


        [BoxGroup("Weapons")]
        [BoxGroup("Weapons/Current")]
        public WeaponManager currentWeapon;
        [BoxGroup("Weapons/Current")]
        public Transform weaponRotator;
        [BoxGroup("Weapons/Current")]
        public Transform currentWeaponObject;
        [BoxGroup("Weapons")]
        public WeaponManager primaryWeapon;
        [BoxGroup("Weapons")]
        public WeaponManager secondaryWeapon;
        [BoxGroup("Weapons")]
        public WeaponManager sideWeapon;

        [BoxGroup("Weapons/Animations")]
        public float timeSinceLastInput;

        [BoxGroup("Weapons/Aiming")]
        public float aimTime;
        [BoxGroup("Weapons/Aiming")]
        public bool isAiming;

        [BoxGroup("Debug")]
        RangedWM ranged;
        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            inputs = InputManager.instance;
        }

        public void Update()
        {
            if (currentWeapon.gameObject.GetComponent<RangedWM>())
            {
                ranged = currentWeapon as RangedWM;
            }
            else
            {
                ranged = null;
            }

            if (!isPaused)
            {
                timeSinceLastInput += Time.deltaTime;


                //if the player hasnt given an input lower the weapon
                if (timeSinceLastInput >= 5)
                {
                    currentWeapon.weaponAnim.CrossFadeInFixedTime(currentWeapon.weaponInfo.animationName + "_Lowered", 0.25f);
                }

                //attack with the weapon
                if (inputs.attackInput)
                {
                    currentWeapon.Attack();
                    timeSinceLastInput = 0f;
                }

                //if a gun reload the weapon
                if (inputs.reloadInput && ranged != null)
                {
                    inputs.reloadInput = false;
                    ranged.Reload();
                    timeSinceLastInput = 0f;
                }

                //if a gun switch the fire mode
                if (inputs.fireSwitchInput && ranged != null)
                {
                    ranged.FireModeSwitch();
                    inputs.fireSwitchInput = false;
                }

                if (inputs.altInput)
                {
                    timeSinceLastInput = 0f;
                    inputs.altInput = false;

                    //if a gun aim
                    if (ranged != null)
                    {
                        isAiming = !isAiming;

                        if (isAiming)
                        {
                            currentWeapon.weaponAnim.CrossFadeInFixedTime(currentWeapon.weaponInfo.animationName + "_Aim_Idle", 0.25f);
                        }
                        else
                        {
                            currentWeapon.weaponAnim.CrossFadeInFixedTime(currentWeapon.weaponInfo.animationName + "_Idle", 0.25f);
                        }
                    }
                }
            }
        }

    }
}