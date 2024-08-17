using UnityEngine;

public class PaddleControllerBase : MonoBehaviour
{
    // Speed factor to control how fast the paddle moves
    public float scrollSpeed = 10f;

    // The limits for the paddle's movement on the Y-axis
    public float minY = 0.75f;
    public float maxY = 9.25f;

    // Speed of interpolation
    public float interpolationSpeed = 5f;

    // Target Y position for the paddle
    protected float targetYPosition;

    public virtual void Start()
    {
        // Initialize target position to the current Y position
        targetYPosition = transform.position.y;
    }

    protected void AdjustPosition()
    {
        // Clamp the target Y position to stay within the defined limits
        targetYPosition = Mathf.Clamp(targetYPosition, minY, maxY);

        // Smoothly interpolate towards the target position
        float newYPosition = Mathf.Lerp(transform.position.y, targetYPosition, interpolationSpeed * Time.deltaTime);

        // Apply the new position to the paddle
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        //Transfer some velocity to the ball if moving.
        if (targetYPosition != transform.position.y)
        {
            var rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.linearVelocityY += (targetYPosition - transform.position.y);
        }
    }
}
