using UnityEngine;

public class BallStarter : MonoBehaviour
{
    public GameObject Ball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            if (FindFirstObjectByType<BallController>() == null)
            {
                GameObject.Instantiate(Ball);
            }
        }
    }
}
