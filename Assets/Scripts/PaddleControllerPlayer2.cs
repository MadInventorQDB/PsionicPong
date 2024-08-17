using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleControllerPlayer2 : PaddleControllerBase
{
    void Update()
    {
        float scrollInput = 0.0f;

        if (Keyboard.current.oKey.IsPressed())
        {
            scrollInput += 0.02f;
        }
        if (Keyboard.current.kKey.IsPressed())
        {
            scrollInput += -0.02f;
        }

        // Calculate the target Y position based on the scroll input and speed
        targetYPosition += scrollInput * scrollSpeed;

        //Clamp, smooth, and apply the new position
        AdjustPosition();
    }
}
