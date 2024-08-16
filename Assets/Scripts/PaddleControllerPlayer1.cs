using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleControllerPlayer1 : MonoBehaviour
{
    // Speed factor to control how fast the paddle moves
    public float scrollSpeed = 10f;

    // The limits for the paddle's movement on the Y-axis
    public float minY = 0.75f;
    public float maxY = 9.25f;

    // Speed of interpolation
    public float interpolationSpeed = 5f;

    // Target Y position for the paddle
    private float targetYPosition;

    void Start()
    {
        // Initialize target position to the current Y position
        targetYPosition = transform.position.y;
    }

    void Update()
    {
        float scrollInput = 0.0f;

        if (Keyboard.current.wKey.IsPressed())
        {
            scrollInput += 0.02f;
        }
        if (Keyboard.current.sKey.IsPressed())
        {
            scrollInput += -0.02f;
        }

        if (!Keyboard.current.wKey.IsPressed() &&
            !Keyboard.current.sKey.IsPressed())
        {
            // Get the scroll wheel input (Mouse ScrollWheel)
            scrollInput = Input.GetAxis("Mouse ScrollWheel");
        }

        // Calculate the target Y position based on the scroll input and speed
        targetYPosition += scrollInput * scrollSpeed;

        // Clamp the target Y position to stay within the defined limits
        targetYPosition = Mathf.Clamp(targetYPosition, minY, maxY);

        // Smoothly interpolate towards the target position
        float newYPosition = Mathf.Lerp(transform.position.y, targetYPosition, interpolationSpeed * Time.deltaTime);

        // Apply the new position to the paddle
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (targetYPosition != transform.position.y)
        { 
            var rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.linearVelocityY += (targetYPosition - transform.position.y);
        }
    }
}
