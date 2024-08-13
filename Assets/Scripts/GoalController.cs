using UnityEngine;

public class GoalController : MonoBehaviour
{
    int playerGoalIndex = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //find which goal
        if (transform.position.x > 0)
        {
            playerGoalIndex = 0;
        }
        else
        { 
            playerGoalIndex = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerGoalIndex == 0)
        {
            ScoreKeeper.Instance.AddScorePlayer1(1);
        }
        else
        {
            ScoreKeeper.Instance.AddScorePlayer2(1);
        }

        Destroy(collision.gameObject);
    }
}
