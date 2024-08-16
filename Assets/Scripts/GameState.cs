using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }

    private const string BallTag = "Ball";
    private const string GameStateUITag = "GameStateUI";
    private const string RightPaddleInstructionsTag = "RightPaddleInstructions";
    private GameObject gameStateUI;
    private GameObject rightPaddleInstructions;

    private PaddleControllerPlayer2 paddleControllerPlayer2;
    private PaddleControllerPlayerAI paddleControllerPlayerAI;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this instance alive across scenes
        }
        else
        {
            Destroy(gameObject); // If another instance exists, destroy this one
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameStateUI = GameObject.FindGameObjectWithTag(GameStateUITag);

        rightPaddleInstructions = GameObject.FindGameObjectWithTag(RightPaddleInstructionsTag);

        UpdateUIState();

        paddleControllerPlayer2 = FindFirstObjectByType<PaddleControllerPlayer2>();
        paddleControllerPlayerAI = FindFirstObjectByType<PaddleControllerPlayerAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            UpdateUIState();
        }
    }

    private void UpdateUIState()
    {
        Time.timeScale = Time.timeScale == 0.0f ? 1.0f : 0.0f;
        gameStateUI.SetActive(Time.timeScale == 0.0f);
    }

    public void Restart1Player()
    {
        rightPaddleInstructions.SetActive(false);
        paddleControllerPlayerAI.enabled = true;
        paddleControllerPlayer2.enabled = false;
        ResetGame();
    }

    public void Restart2Player()
    {
        rightPaddleInstructions.SetActive(true);
        paddleControllerPlayerAI.enabled = false;
        paddleControllerPlayer2.enabled = true;
        ResetGame();
    }

    private static void ResetGame()
    {
        ScoreKeeper.Instance.ResetScores();
        var ball = GameObject.FindGameObjectWithTag(BallTag);
        if (ball != null)
        {
            Destroy(ball);
        }
        Instance.UpdateUIState();
    }

    public void Quit()
    { 
        Application.Quit();
    }
}
