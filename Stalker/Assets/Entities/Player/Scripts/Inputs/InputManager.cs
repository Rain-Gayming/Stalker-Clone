using System.Collections;
using System.Collections.Generic;
using QFSW.QC;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

namespace RainGayming.Inputs
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager instance;

        PlayerInputs inputs;
        public bool isPaused;
        public QuantumKeyConfig consoleKey;
        [Header("Movement Inputs")]
        public Vector2 movementInput;
        public bool jumpInput;
        public bool sprintInput;
        public bool crouchInput;

        [Header("Camera")]
        public Vector2 cameraLook;

        [Header("Combat")]
        public bool attackInput;
        public bool altInput;
        public bool reloadInput;
        public bool sideInput;
        public bool primaryInput;
        public bool secondaryInput;
        public bool fireSwitchInput;

        private void Awake()
        {
            instance = this;
            inputs = new PlayerInputs();
        }

        private void OnEnable()
        {
            inputs.Enable();
        }

        void Update()
        {
            if (consoleKey.ToggleConsoleVisibilityKey.IsPressed())
            {
                isPaused = !isPaused;
            }
            if (!isPaused)
            {
                movementInput = inputs.Movement.movement.ReadValue<Vector2>();
                cameraLook = inputs.Camera.look.ReadValue<Vector2>();

                inputs.Movement.jump.performed += _ => jumpInput = true;
                inputs.Movement.jump.canceled += _ => jumpInput = false;
                inputs.Movement.crouch.performed += _ => crouchInput = true;
                inputs.Movement.crouch.canceled += _ => crouchInput = false;
                inputs.Movement.sprint.performed += _ => sprintInput = true;
                inputs.Movement.sprint.canceled += _ => sprintInput = false;

                inputs.Combat.attack.performed += _ => attackInput = true;
                inputs.Combat.attack.canceled += _ => attackInput = false;
                inputs.Combat.alt.performed += _ => altInput = true;
                inputs.Combat.alt.canceled += _ => altInput = false;
                inputs.Combat.side.performed += _ => sideInput = true;
                inputs.Combat.side.canceled += _ => sideInput = false;
                inputs.Combat.primary.performed += _ => primaryInput = true;
                inputs.Combat.primary.canceled += _ => primaryInput = false;
                inputs.Combat.secondary.performed += _ => secondaryInput = true;
                inputs.Combat.secondary.canceled += _ => secondaryInput = false;
                inputs.Combat.fireSwitch.performed += _ => fireSwitchInput = true;
                inputs.Combat.fireSwitch.canceled += _ => fireSwitchInput = false;
            }
        }
    }
}