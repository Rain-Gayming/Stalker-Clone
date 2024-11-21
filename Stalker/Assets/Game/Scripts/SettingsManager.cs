using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RainGayming.Settings
{
    public class SettingsManager : MonoBehaviour
    {

        public static SettingsManager instance;
    
        [Range(5f, 50f)]
        public float sensX;
        [Range(5f, 50f)]
        public float sensY;
        public bool invertCameraX;
        public bool invertCameraY;

        [Header("Gameplay")]
        public bool hasItemDegredation = true;

        public void Awake()
        {
            if (instance)
            {
                Destroy(instance);
            }
            else
            {
                instance = this;
            }
        }
    }   
}