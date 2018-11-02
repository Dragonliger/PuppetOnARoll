using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMotor : MonoBehaviour
{
    public float speed = 12.0f;
    // Modify only for mouse input.
    public float SpatialModifier = 1.0f;
    public float DownSpeed = 1.0f;
    public float UpSpeed = 2.0f;
    public float DefaultHeight = 6.11f;
    public float MinimumHeight = 2.1f;
    public float LeftInvisiwall = -20.0f;
    public float RightInvisiwall = 20.0f;
    public float FrontInvisiwall = 16.0f;
    public float BackInvisiwall = -9.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get control changes. Maybe change for default axis and just
        // configure through unity.
        float HorizontalInput = Input.GetAxis("Horizontal");
        float HorizontalSpeed = HorizontalInput * speed * Time.deltaTime * SpatialModifier;
        float VerticalInput = Input.GetAxis("Vertical");
        float VerticalSpeed = VerticalInput * speed * Time.deltaTime * SpatialModifier;
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
        if (HorizontalSpeed < 0)
        {
            // Check left invisiwall.
            float Difference = LeftInvisiwall - XPosition;
            if (Difference > HorizontalSpeed)
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
            }
        }
        else
        {
            // Check front invisiwall.
            float Difference = FrontInvisiwall - ZPosition;
            if (Difference < VerticalSpeed)
            {
                VerticalSpeed = Difference;
            }
        }

        // Apply translation.
        gameObject.transform.Translate(new Vector3(HorizontalSpeed, YAxisMovement, VerticalSpeed));
    }
}
