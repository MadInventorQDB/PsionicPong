using UnityEngine;
using UnityEngine.InputSystem;

public class PaddleControllerPlayer1 : PaddleControllerBase
{
    void Update()
    {
        float scrollInput = 0.0f;

        if (Keyboard.current.wKey.IsPressed())
        {
            scrollInput += 0.02f;
        }
        if (Keyboard.current.sKey.IsPressed())
        {
            scrollInput += -0.02f;
        }

        if (!Keyboard.current.wKey.IsPressed() &&
            !Keyboard.current.sKey.IsPressed())
        {
            // Get the scroll wheel input (Mouse ScrollWheel)
            scrollInput = Input.GetAxis("Mouse ScrollWheel");
        }

        // Calculate the target Y position based on the scroll input and speed
        targetYPosition += scrollInput * scrollSpeed;

        //Clamp, smooth, and apply the new position
        AdjustPosition();
    }
}
