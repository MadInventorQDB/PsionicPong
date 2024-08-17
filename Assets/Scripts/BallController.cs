using System;
using UnityEngine;
using UnityEngine.Audio;

public class BallController : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;
    private Rigidbody2D rb;

    public event Action OnDestroyed;
    public event Action OnStarted;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // Turn off gravity

        float randomAngle;
        // Set initial random direction at 60 degrees left or right randomly.
        if (UnityEngine.Random.Range(-1f, 1f) > 0.0)
        {
            randomAngle = UnityEngine.Random.Range(30f, -30f);
        }
        else 
        {
            randomAngle = UnityEngine.Random.Range(30f, -30f) + 180f;
        }

        direction = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));

        // Apply initial velocity
        rb.linearVelocity = direction * speed;

        OnStarted.Invoke();
    }

    private void OnDestroy()
    {
        OnDestroyed.Invoke();
    }
}