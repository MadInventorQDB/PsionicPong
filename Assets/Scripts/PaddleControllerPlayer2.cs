using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleControllerPlayer2 : MonoBehaviour
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

        if (Keyboard.current.oKey.IsPressed())
        {
            scrollInput += 0.02f;
        }
        if (Keyboard.current.kKey.IsPressed())
        {
            scrollInput += -0.02f;
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
}
