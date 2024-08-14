using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }

    private const string BallTag = "Ball";
    private const string GameStateUITag = "GameStateUI";
    public GameObject gameStateUI;

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
        gameStateUI.SetActive(Time.timeScale == 0.0f);
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
        
    }

    public void Restart2Player() 
    {
        ScoreKeeper.Instance.ResetScores();
        var ball = GameObject.FindGameObjectWithTag(BallTag);
        if (ball != null)
        { 
            Destroy(ball);
        }
        UpdateUIState();
    }

    public void Quit()
    { 
        Application.Quit();
    }
}
