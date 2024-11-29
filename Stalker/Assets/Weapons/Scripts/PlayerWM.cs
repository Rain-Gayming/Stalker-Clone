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

            if (!isPaused)
            {
                if (inputs.attackInput)
                {
                    currentWeapon.Attack();
                }
                if (inputs.reloadInput)
                {
                    inputs.reloadInput = false;
                    ranged.Reload();
                }
                if (inputs.fireSwitchInput)
                {
                    ranged.FireModeSwitch();
                    inputs.fireSwitchInput = false;
                }

                if (inputs.altInput)
                {
                    inputs.altInput = false;

                    isAiming = !isAiming;

                    if (isAiming)
                    {
                        currentWeapon.weaponAnim.CrossFadeInFixedTime(currentWeapon.weaponInfo.animationName + "_Aim_Idle", 1f);
                    }
                    else
                    {
                        currentWeapon.weaponAnim.Play(currentWeapon.weaponInfo.animationName + "_Idle");
                    }
                }
            }
        }

    }
}