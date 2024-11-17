using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.EventSystems;

using RainGayming.Inputs;

namespace RainGayming.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("References")]
        public Rigidbody rb;
        public InputManager inputManager;
        public Transform orientation;

        [Header("Speed")]
        public float currentSpeed;
        public float walkSpeed;
        public float runSpeed;
        public float crouchSpeed;
        public float speedMultiplier = 1;


        [Header("Jumping")]
        public LayerMask whatIsGround;
        public Transform groundCheckPoint;
        public bool isGrounded;
        public float groundRadius;
        public float jumpHeight;
        public float jumpMultiplier = 1;

        [Header("Drag")]
        public float groundDrag;

        [Header("Step")]
        public float maxStepHeight;
        public float wallDistance;
        public bool hasWallInfront;
        public Transform wallCheckPoint;

        [Header("Debug")]
        public float horizontalInput;
        public float verticalInput;
        public Vector3 movementDirection;

        private void Start()
        {
            inputManager = InputManager.instance;
            rb.freezeRotation = true;

            currentSpeed = walkSpeed;
            wallCheckPoint.position = new Vector3(wallCheckPoint.position.x, maxStepHeight, wallCheckPoint.position.z);
        }

        private void Update()
        {
            horizontalInput = inputManager.movementInput.x;
            verticalInput = inputManager.movementInput.y;

            isGrounded = Physics.Raycast(groundCheckPoint.position, -groundCheckPoint.up, groundRadius, whatIsGround);
            hasWallInfront = Physics.Raycast(groundCheckPoint.position, groundCheckPoint.forward, wallDistance, whatIsGround);

            //if the player is moving forward
            if (verticalInput! >= 0.5)
            {
                if (hasWallInfront)
                {
                    //checks if the wall isnt too high
                    if (!Physics.Raycast(wallCheckPoint.position, groundCheckPoint.forward, wallDistance, whatIsGround))
                    {
                        //sets the players y pos to the right one
                        transform.position = new Vector3(transform.position.x, transform.position.y + maxStepHeight, transform.position.z);

                        //pushes the player forward
                        rb.AddForce(orientation.forward * maxStepHeight, ForceMode.Impulse);
                    }
                }
            }

            if (isGrounded)
            {
                rb.drag = groundDrag;
            }
            else
            {
                rb.drag = 0;
            }

            if (inputManager.jumpInput)
            {
                Jump();
            }

            SpeedControl();
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        public void Jump()
        {
            if (isGrounded)
            {
                inputManager.jumpInput = false;

                rb.AddForce(transform.up * jumpHeight * jumpMultiplier, ForceMode.Impulse);
            }
        }

        public void SpeedControl()
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (flatVel.magnitude > currentSpeed * speedMultiplier)
            {
                Vector3 limitedVel = flatVel.normalized * currentSpeed * speedMultiplier;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }

        public void MovePlayer()
        {
            movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

            rb.AddForce(movementDirection.normalized * currentSpeed * 10f * speedMultiplier, ForceMode.Force);
        }

    }
}