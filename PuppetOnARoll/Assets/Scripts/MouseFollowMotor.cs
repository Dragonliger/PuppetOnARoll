using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollowMotor : MonoBehaviour
{

    public float speed = 12.0f;
    public float DownSpeed = 25.0f;
    public float UpSpeed = 20.0f;
    public float DefaultHeight = 6.11f;
    public float MinimumHeight = 2.6f;
    public float LeftInvisiwall = -20.0f;
    public float RightInvisiwall = 20.0f;
    public float FrontInvisiwall = 16.0f;
    public float BackInvisiwall = -9.0f;

    private float movingflag = 1.0f;
    public bool flagstop = true;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculates the mouse position in the screen so the player moves in
        // relation with the screen center.
        Vector2 MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 ScreenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        float HorizontalInput = (MousePosition.x - ScreenCenter.x) / ScreenCenter.x;
        float HorizontalSpeed = HorizontalInput * speed * Time.deltaTime;
        float VerticalInput = (MousePosition.y - ScreenCenter.y) / ScreenCenter.y;
        float VerticalSpeed = VerticalInput * speed * Time.deltaTime;
        float YAxisMovement = 0.0f;
        float YPosition = gameObject.transform.position.y;
        float XPosition = gameObject.transform.position.x;
        float ZPosition = gameObject.transform.position.z;

        // Left click to go down.
        if (Input.GetButton("Fire1"))
        {
            if (YPosition > MinimumHeight)
            {
                YAxisMovement = -1.0f * DownSpeed * Time.deltaTime;
                // This makes the hand snap to the lower limit instead of
                // going through it.
                float Difference = YPosition - MinimumHeight;
                if (-YAxisMovement > Difference)
                {
                    YAxisMovement = Difference * -1.0f;
                }
            }

        }
        // When the button is released the hand goes up again.
        else if (gameObject.transform.position.y < DefaultHeight)
        {
            YAxisMovement = 1.0f * UpSpeed * Time.deltaTime;
            // This makes the hand snap to the default position for the hand.
            float Difference = DefaultHeight - YPosition;
            if (YAxisMovement > Difference)
            {
                YAxisMovement = Difference;
            }
        }

        // Going left
        if(HorizontalSpeed < 0)
        {
            // Check left invisiwall.
            float Difference = LeftInvisiwall - XPosition;
            if(Difference > HorizontalSpeed)
            {
                HorizontalSpeed = Difference;
            }
        }
        else
        {
            // Check right invisiwall.
            float Difference = RightInvisiwall - XPosition;
            if (Difference < HorizontalSpeed)
            {
                HorizontalSpeed = Difference;
            }
        }

        // Going down
        if (VerticalSpeed < 0)
        {
            // Check back invisiwall.
            float Difference = BackInvisiwall - ZPosition;
            if (Difference > VerticalSpeed)
            {
                VerticalSpeed = Difference;
                //if(flagstop)
                    //movingflag = 0.0f;
            }
        }
        else
        {
            // Check front invisiwall.
            float Difference = FrontInvisiwall - ZPosition;
            if (Difference < VerticalSpeed)
            {
                VerticalSpeed = Difference;
                if(flagstop)
                    movingflag = 1.0f;
            }
        }

        // Apply translation.
        gameObject.transform.Translate(new Vector3(HorizontalSpeed * movingflag, YAxisMovement, VerticalSpeed));
    }
}
