using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.Settings
{
    public class SettingsManager : MonoBehaviour
    {

        public static SettingsManager instance;

        [BoxGroup("Inputs")]
        [BoxGroup("Inputs/Camera")]    
        [Range(5f, 50f)]
        public float sensX;
        [BoxGroup("Inputs/Camera")]    
        [Range(5f, 50f)]
        public float sensY;
        [BoxGroup("Inputs/Camera")]    
        public bool invertCameraX;
        [BoxGroup("Inputs/Camera")]    
        public bool invertCameraY;

        [BoxGroup("Gameplay")]
        [BoxGroup("Gameplay/Items")]    
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