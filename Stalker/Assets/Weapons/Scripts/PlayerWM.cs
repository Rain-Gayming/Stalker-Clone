using System.Collections;
using System.Collections.Generic;
using RainGayming.Combat;
using RainGayming.Game;
using RainGayming.Inputs;
using Sirenix.OdinInspector;
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
        public WeaponManager currentWeapon;
        [BoxGroup("Weapons")]
        public WeaponManager primaryWeapon;
        [BoxGroup("Weapons")]
        public WeaponManager secondaryWeapon;
        [BoxGroup("Weapons")]
        public WeaponManager sideWeapon;

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
            if (!isPaused)
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
                if (inputs.fireSwitchInput)
                {
                    RangedWM ranged = currentWeapon as RangedWM;
                    ranged.FireModeSwitch();
                    inputs.fireSwitchInput = false;
                }
            }
        }

    }
}