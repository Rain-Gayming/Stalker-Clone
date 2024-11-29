using System.Collections;
using System.Collections.Generic;
using RainGayming.Inventory;
using Sirenix.OdinInspector;
using UnityEngine;


namespace RainGayming.Combat
{
    public class WeaponManager : MonoBehaviour
    {
    
        public bool isPaused;
        [BoxGroup("References")]
        public WeaponItem weaponInfo;

        [BoxGroup("References")]
        public Animator weaponAnim;

        public virtual void Attack()
        {
            if (isPaused)
                return; 
        } 
    }

}