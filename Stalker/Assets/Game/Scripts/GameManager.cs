using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using QFSW.QC;
using RainGayming.Combat;
using RainGayming.Inputs;
using RainGayming.Misc;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RainGayming.Game
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        [BoxGroup("References")]
        public InputManager inputManager;
        [BoxGroup("References")]
        public CursorManager cursorManager;
        [BoxGroup("References")]
        public PlayerWM playerWM;

        [BoxGroup("Info")]
        public bool isPaused;

        [BoxGroup("Consle")]
        public QuantumKeyConfig consoleKeys;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            cursorManager = CursorManager.instance;
            inputManager = InputManager.instance;
        }

        public void Update()
        {
            if (consoleKeys.ToggleConsoleVisibilityKey.IsPressed())
            {
                isPaused = !isPaused;
                inputManager.isPaused = isPaused;
                cursorManager.isPaused = isPaused;
                playerWM.isPaused = isPaused;
            }
        }
    }
}