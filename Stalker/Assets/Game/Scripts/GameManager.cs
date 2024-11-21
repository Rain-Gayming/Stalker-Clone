using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using QFSW.QC;
using RainGayming.Inputs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.Game
{
    public class GameManager : MonoBehaviour
    {
        [BoxGroup("References")]
        public InputManager inputManager;

        [BoxGroup("Info")]
        public bool isPaused;

        [BoxGroup("Consle")]
        public QuantumKeyConfig consoleKeys;

        private void Start()
        {
            inputManager = InputManager.instance;
        }

        public void Update()
        {
            if (consoleKeys.ToggleConsoleVisibilityKey.IsPressed())
            {
                isPaused = !isPaused;
                inputManager.isPaused = isPaused;
            }
        }
    }
}