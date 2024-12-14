using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Speed of movement
    [SerializeField] private float gravity = -9.81f; // Gravity force
    [SerializeField] private float jumpHeight = 1.5f; // Height of the jump

    private CharacterController characterController; // Reference to the CharacterController
    private Vector3 velocity; // Current velocity of the player
    private bool isGrounded; // Whether the player is grounded

    void Start()
    {
        // Get the CharacterController component
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Skip all movement logic if the game is paused
        if (MenuPausa.isGamePaused)
        {
            return;
        }

        // Check if the player is grounded
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset vertical velocity when grounded
        }

        // Get input for movement along the X and Z axes
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow keys
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down Arrow keys

        // Calculate movement direction relative to the world
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Move the player using the CharacterController
        characterController.Move(move * moveSpeed * Time.deltaTime);

        // Apply jump if grounded and spacebar is pressed
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply the vertical velocity to the player
        characterController.Move(velocity * Time.deltaTime);
    }
}
