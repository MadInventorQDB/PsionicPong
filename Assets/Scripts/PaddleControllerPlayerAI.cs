using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleControllerPlayerAI : PaddleControllerBase
{
    PlayController playController;
    BallController ballController;

    public override void Start()
    {
        playController = FindFirstObjectByType<PlayController>();
        playController.OnBallControllerCreated += OnBallControllerCreated;

        base.Start();
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

            //Clamp, smooth, and apply the new position
            AdjustPosition();
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        //I don't want to transfer velocity to the ball from the AI.
    }
}
