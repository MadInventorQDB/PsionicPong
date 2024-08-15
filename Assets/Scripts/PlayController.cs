using System;
using UnityEngine;

public class PlayController : MonoBehaviour
{
    public GameObject Instructions;
    public GameObject Ball;

    private BallController ballController;

    public Action<BallController> OnBallControllerCreated;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Space))
        {
            if (FindFirstObjectByType<BallController>() == null)
            {
                var ballGo = GameObject.Instantiate(Ball);
                Instructions.SetActive(false);
                ballController = ballGo.GetComponent<BallController>();
                OnBallControllerCreated.Invoke(ballController);
                ballController.OnStarted += BallController_OnStarted;
                ballController.OnDestroyed += BallController_OnDestroyed;
            }
        }
    }

    private void BallController_OnStarted()
    {
        Instructions.SetActive(false);
        ballController.OnStarted -= BallController_OnStarted;
    }

    private void BallController_OnDestroyed()
    {
        Instructions.SetActive(true);
        ballController.OnDestroyed -= BallController_OnDestroyed;
    }
}
