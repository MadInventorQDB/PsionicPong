using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public const string P1Score = "P1Score";
    public const string P2Score = "P2Score";

    // Static instance of ScoreManager, so it can be accessed from anywhere
    public static ScoreKeeper Instance { get; private set; }

    // Player scores
    private int player1Score = 0;
    private int player2Score = 0;

    private TextMeshProUGUI player1ScoreUI;
    private TextMeshProUGUI player2ScoreUI;

    // Ensure the instance is the only one and persists across scenes
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

    void Start()
    {
        //Set the UI componets to update for score.
        player1ScoreUI = GameObject.FindGameObjectWithTag(P1Score).GetComponent<TextMeshProUGUI>();
        player2ScoreUI = GameObject.FindGameObjectWithTag(P2Score).GetComponent<TextMeshProUGUI>();
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        player1ScoreUI.text = $"P1 : {player1Score}";
        player2ScoreUI.text = $"P2 : {player2Score}";
    }

    // Methods to modify player scores
    public void AddScorePlayer1(int amount)
    {
        player1Score += amount;
        UpdateScoreUI();
    }

    public void AddScorePlayer2(int amount)
    {
        player2Score += amount;
        UpdateScoreUI();
    }

    public int GetScorePlayer1()
    {
        return player1Score;
    }

    public int GetScorePlayer2()
    {
        return player2Score;
    }

    // Method to reset the scores (optional, if needed)
    public void ResetScores()
    {
        player1Score = 0;
        player2Score = 0;
        UpdateScoreUI();
    }
}
