using System.Collections;
using System.Collections.Generic;
using RainGayming.Combat;
using RainGayming.Inputs;
using UnityEngine;

namespace RainGayming.Combat
{
    public class PlayerWM : MonoBehaviour
    {
        [Header("Reference")]
        public InputManager inputs;


        [Header("Weapons")]
        public WeaponManager currentWeapon;
        public WeaponManager primaryWeapon;
        public WeaponManager secondaryWeapon;
        public WeaponManager sideWeapon;

        private void Start()
        {
            inputs = InputManager.instance;
        }

        public void Update()
        {
            if (inputs.attackInput)
            {
                currentWeapon.Attack();
            }
            if (inputs.reloadInput)
            {
                inputs.reloadInput = false;
                RangedWM ranged = currentWeapon as RangedWM;
                ranged.Reload();
            }
        }

    }
}