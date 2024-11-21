using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using RainGayming.Inputs;
using RainGayming.Settings;

namespace RainGayming.Player
{
    public class PlayerCamera : MonoBehaviour
    {

        [Header("References")]
        public SettingsManager settingsManager;
        public InputManager inputManager;
        public GameObject orientation;

        [Header("Debug")]
        public float yRotation;
        public float xRotation;

        // Start is called before the first frame update
        void Start()
        {
            inputManager = InputManager.instance;
            settingsManager = SettingsManager.instance;
        }

        // Update is called once per frame
        void Update()
        {
            //gets the mouse input
            float mouseX = inputManager.cameraLook.x * Time.deltaTime * settingsManager.sensX;
            float mouseY = inputManager.cameraLook.y * Time.deltaTime * settingsManager.sensY;

            //checks if the player wants to invert the input
            if (!settingsManager.invertCameraY)
            {
                yRotation += mouseX;
            }
            else
            {
                yRotation -= mouseX;
            }

            if (!settingsManager.invertCameraX)
            {
                xRotation -= mouseY;
            }
            else
            {
                xRotation += mouseY;
            }
            //makes it so you cant flip the camera
            xRotation = Mathf.Clamp(xRotation, -80, 80);

            //rotates the camera
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);

        }
    }
}