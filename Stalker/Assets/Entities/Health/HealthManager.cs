using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.Collections;
using UnityEngine;

namespace RainGayming.Health
{
    public class HealthManager : MonoBehaviour
    {
        [BoxGroup("Limbs")]
        public float limbMaxHealth;
        [BoxGroup("Limbs")]
        public float headMaxHealth;
        [BoxGroup("Limbs")]
        public float chestMaxHealth;

        #region limb health

        [BoxGroup("Limbs/Health")]
        public float headHealth;
        [BoxGroup("Limbs/Health")]
        public float chestHealth;
        [BoxGroup("Limbs/Health")]
        public float bodyHealth;
        [BoxGroup("Limbs/Health")]
        public float leftArmHealth;
        [BoxGroup("Limbs/Health")]
        public float rightArmHealth;
        [BoxGroup("Limbs/Health")]
        public float leftLegHealth;
        [BoxGroup("Limbs/Health")]
        public float rightLegHealth;

        #endregion

        #region limb status

        [BoxGroup("Limbs/Status")]
        public bool isLeftArmBroken;
        [BoxGroup("Limbs/Status")]
        public bool isRightArmBroken;
        [BoxGroup("Limbs/Status")]
        public bool isLeftLegBroken;
        [BoxGroup("Limbs/Status")]
        public bool isRightLegBroken;

        #endregion

        private void Start()
        {
            headHealth = headMaxHealth;
            chestHealth = chestMaxHealth;
            bodyHealth = limbMaxHealth;
            leftArmHealth = limbMaxHealth;
            rightArmHealth = limbMaxHealth;
            leftLegHealth = limbMaxHealth;
            rightLegHealth = limbMaxHealth;
        }

        public void ChangeHealth(bool isDamage, float change, Limb limb)
        {
            //limb health
            switch (limb)
            {
                case Limb.head:
                    if (isDamage)
                    {
                        headHealth -= change;
                    }
                    else
                    {
                        headHealth += change;
                    }
                    break;
                case Limb.chest:
                    if (isDamage)
                    {
                        chestHealth -= change;
                    }
                    else
                    {
                        chestHealth += change;
                    }
                    break;
                case Limb.body:
                    if (isDamage)
                    {
                        bodyHealth -= change;
                    }
                    else
                    {
                        bodyHealth += change;
                    }
                    break;
                case Limb.leftLeg:
                    if (isDamage)
                    {
                        leftLegHealth -= change;
                    }
                    else
                    {
                        leftLegHealth += change;
                    }

                    isLeftLegBroken = leftLegHealth <= 30 ? true : false;
                    break;
                case Limb.rightLeg:
                    if (isDamage)
                    {
                        rightLegHealth -= change;
                    }
                    else
                    {
                        rightLegHealth += change;
                    }

                    isRightLegBroken = rightLegHealth <= 30 ? true : false;
                    break;
                case Limb.leftArm:
                    if (isDamage)
                    {
                        leftArmHealth -= change;
                    }
                    else
                    {
                        leftArmHealth += change;
                    }

                    isLeftArmBroken = leftArmHealth <= 30 ? true : false;
                    break;
                case Limb.rightArm:
                    if (isDamage)
                    {
                        rightArmHealth -= change;
                    }
                    else
                    {
                        rightArmHealth += change;
                    }

                    isRightArmBroken = rightArmHealth <= 30 ? true : false;
                    break;
            }

            //if your chest or head health is less than 0 you die
            if (headHealth <= 0 || chestHealth <= 0)
            {
                print("dead");
            }

            //adds up the health of your limbs
            float totalLimbHealth = bodyHealth + leftArmHealth + rightArmHealth + leftLegHealth + rightLegHealth;

            //if all limbs are broken you die
            if (totalLimbHealth <= 0)
            {
                print("dead");
            }
        }
    }
}