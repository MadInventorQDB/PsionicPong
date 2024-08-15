using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleControllerPlayerAI : MonoBehaviour
{
    // The limits for the paddle's movement on the Y-axis
    public float minY = 0.75f;
    public float maxY = 9.25f;

    // Speed of interpolation
    public float interpolationSpeed = 5f;

    // Target Y position for the paddle
    private float targetYPosition;

    PlayController playController;
    BallController ballController;


    void Start()
    {
        playController = FindFirstObjectByType<PlayController>();
        playController.OnBallControllerCreated += OnBallControllerCreated; 

        // Initialize target position to the current Y position
        targetYPosition = transform.position.y;
    }

    private void OnBallControllerCreated(BallController controller)
    {
        ballController = controller;
        controller.OnDestroyed += Controller_OnDestroyed;
    }

    private void Controller_OnDestroyed()
    {
        ballController.OnDestroyed -= Controller_OnDestroyed;
        ballController = null;
    }

    void Update()
    {
        if (ballController != null)
        { 
            // Calculate the target Y position based on the scroll input and speed
            targetYPosition = ballController.gameObject.transform.position.y;

            // Clamp the target Y position to stay within the defined limits
            targetYPosition = Mathf.Clamp(targetYPosition, minY, maxY);

            // Smoothly interpolate towards the target position
            float newYPosition = Mathf.Lerp(transform.position.y, targetYPosition, interpolationSpeed * Time.deltaTime);

            // Apply the new position to the paddle
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
        }
    }
}
