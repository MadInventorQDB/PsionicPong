using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    // Static instance of ScoreManager, so it can be accessed from anywhere
    public static ScoreKeeper Instance { get; private set; }

    // Player scores
    private int player1Score = 0;
    private int player2Score = 0;

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

    // Methods to modify player scores
    public void AddScorePlayer1(int amount)
    {
        player1Score += amount;
    }

    public void AddScorePlayer2(int amount)
    {
        player2Score += amount;
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
    }
}
