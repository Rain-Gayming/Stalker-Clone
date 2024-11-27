using System.Collections;
using System.Collections.Generic;
using QFSW.QC;
using Sirenix.OdinInspector;
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
        [BoxGroup("Movement Inputs")]
        public Vector2 movementInput;
        [BoxGroup("Movement Inputs")]

        public bool jumpInput;
        [BoxGroup("Movement Inputs")]

        public bool sprintInput;
        [BoxGroup("Movement Inputs")]

        public bool crouchInput;

        [BoxGroup("Camera")]
        public Vector2 cameraLook;

        [BoxGroup("Combat")]
        public bool attackInput;
        [BoxGroup("Combat")]
        public bool altInput;
        [BoxGroup("Combat")]
        public bool reloadInput;
        [BoxGroup("Combat")]
        public bool sideInput;
        [BoxGroup("Combat")]
        public bool primaryInput;
        [BoxGroup("Combat")]
        public bool secondaryInput;
        [BoxGroup("Combat")]
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
                inputs.Combat.reload.performed += _ => reloadInput = true;
                inputs.Combat.reload.canceled += _ => reloadInput = false;
            }
        }
    }
}