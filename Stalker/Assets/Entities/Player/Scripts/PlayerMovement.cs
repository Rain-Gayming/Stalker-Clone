using UnityEngine;

using RainGayming.Inputs;
using Sirenix.OdinInspector;
using RainGayming.Game;

namespace RainGayming.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public static PlayerMovement instance;
        public bool isPaused;
        [BoxGroup("References")]
        public Rigidbody rb;
        [BoxGroup("References")]
        public InputManager inputManager;
        [BoxGroup("References")]
        public Transform orientation;

        [BoxGroup("Speed")]
        public float currentSpeed;
        [BoxGroup("Speed")]
        public float walkSpeed;
        [BoxGroup("Speed")]
        public float runSpeed;
        [BoxGroup("Speed")]
        public float crouchSpeed;
        [BoxGroup("Speed")]
        public float speedMultiplier = 1;


        [BoxGroup("Jumping")]
        public LayerMask whatIsGround;
        [BoxGroup("Jumping")]
        public Transform groundCheckPoint;
        [BoxGroup("Jumping")]
        public bool isGrounded;
        [BoxGroup("Jumping")]
        public float groundRadius;
        [BoxGroup("Jumping")]
        public float jumpHeight;
        [BoxGroup("Jumping")]
        public float jumpMultiplier = 1;

        [BoxGroup("Drag")]
        public float groundDrag;

        [BoxGroup("Step")]
        public float maxStepHeight;
        [BoxGroup("Step")]
        public float wallDistance;
        [BoxGroup("Step")]
        public bool hasWallInfront;
        [BoxGroup("Step")]
        public Transform wallCheckPoint;
        [BoxGroup("Step")]
        public LayerMask whatIsStepable;

        [BoxGroup("Debug")]
        public float horizontalInput;
        [BoxGroup("Debug")]
        public float verticalInput;
        [BoxGroup("Debug")]
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
            if (!GameManager.instance.isPaused)
            {
                horizontalInput = inputManager.movementInput.x;
                verticalInput = inputManager.movementInput.y;

                isGrounded = Physics.Raycast(groundCheckPoint.position, -groundCheckPoint.up, groundRadius, whatIsGround);
                hasWallInfront = Physics.Raycast(groundCheckPoint.position, groundCheckPoint.forward, wallDistance, whatIsStepable);

                //if the player is moving forward
                if (verticalInput! >= 0.5)
                {
                    if (hasWallInfront)
                    {
                        //checks if the wall isnt too high
                        if (!Physics.Raycast(wallCheckPoint.position, groundCheckPoint.forward, wallDistance))
                        {
                            print("Stepping");
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