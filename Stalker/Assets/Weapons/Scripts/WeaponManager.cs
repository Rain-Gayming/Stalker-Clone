using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RainGayming.Combat
{
    public class WeaponManager : MonoBehaviour
    {
        public bool isPaused;
        public virtual void Attack()
        {
            if (isPaused)
                return;

        }
    }

}
