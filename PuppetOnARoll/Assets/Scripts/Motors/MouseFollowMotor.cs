using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollowMotor : MonoBehaviour
{

<<<<<<< HEAD
    //public float speed = 12.0f;
    //public float DragSpeed = 1.0f;
    //public float DownSpeed = 25.0f;
    //public float UpSpeed = 20.0f;
    //public float DefaultHeight = 6.11f;
    //public float MinimumHeight = 2.6f;
    //public float LeftInvisiwall = -20.0f;
    //public float RightInvisiwall = 20.0f;
    //public float FrontInvisiwall = 16.0f;
    //public float BackInvisiwall = -9.0f;
    //public bool Playing = true;
    //public GameObject ResetPoint;
    //public float ReturnSpeed = 6.0f;
=======
    public float speed = 12.0f;
    public float DragSpeed = 1.0f;
    public float DownSpeed = 25.0f;
    public float UpSpeed = 20.0f;
    public float DefaultHeight = 6.11f;
    public float MinimumHeight = 2.6f;
    public float LeftInvisiwall = -20.0f;
    public float RightInvisiwall = 20.0f;
    public float FrontInvisiwall = 16.0f;
    public float BackInvisiwall = -9.0f;
    public bool Playing = true;
>>>>>>> parent of c32c382... PrototypeDone

    private Values ValueClass;
    private float RealSpeed = 0.0f;

    private void Awake()
    {
        ValueClass = gameObject.GetComponent<Values>();
    }

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        RealSpeed = ValueClass.speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculates the mouse position in the screen so the player moves in
        // relation with the screen center.
        Vector2 MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 ScreenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        float HorizontalInput = (MousePosition.x - ScreenCenter.x) / ScreenCenter.x;
        float VerticalInput = (MousePosition.y - ScreenCenter.y) / ScreenCenter.y;
        float YAxisMovement = 0.0f;
        float YPosition = gameObject.transform.position.y;
        float XPosition = gameObject.transform.position.x;
        float ZPosition = gameObject.transform.position.z;

        // Clicking.
        // Left click to go down.
        if (Input.GetButton("GoDown"))
        {
            RealSpeed = ValueClass.DragSpeed;
            if (YPosition > ValueClass.MinimumHeight)
            {
                YAxisMovement = -1.0f * ValueClass.DownSpeed * Time.deltaTime;
                // This makes the hand snap to the lower limit instead of
                // going through it.
                float Difference = YPosition - ValueClass.MinimumHeight;
                if (-YAxisMovement > Difference)
                {
                    YAxisMovement = Difference * -1.0f;
                }
            }
        }
        // When the button is released the hand goes up again.
        else if (YPosition < ValueClass.DefaultHeight)
        {
            RealSpeed = ValueClass.speed;
            YAxisMovement = 1.0f * ValueClass.UpSpeed * Time.deltaTime;
            // This makes the hand snap to the default position for the hand.
            float Difference = ValueClass.DefaultHeight - YPosition;
            if (YAxisMovement > Difference)
            {
                YAxisMovement = Difference;
            }
        }

        // Speeds
        float HorizontalSpeed = HorizontalInput * RealSpeed * Time.deltaTime;
        float VerticalSpeed = VerticalInput * RealSpeed * Time.deltaTime;

        // Collisions
        // Going left
        if(HorizontalSpeed < 0)
        {
            // Check left invisiwall.
            float Difference = ValueClass.LeftInvisiwall - XPosition;
            if(Difference > HorizontalSpeed)
            {
                HorizontalSpeed = Difference;
            }
        }
        else
        {
            // Check right invisiwall.
            float Difference = ValueClass.RightInvisiwall - XPosition;
            if (Difference < HorizontalSpeed)
            {
                HorizontalSpeed = Difference;
            }
        }

        // Going back
        if (VerticalSpeed < 0)
        {
            // Check back invisiwall.
            float Difference = ValueClass.BackInvisiwall - ZPosition;
            if (Difference > VerticalSpeed)
            {
                VerticalSpeed = Difference;
            }
        }
        else
        {
            // Check front invisiwall.
            float Difference = ValueClass.FrontInvisiwall - ZPosition;
            if (Difference < VerticalSpeed)
            {
                VerticalSpeed = Difference;
            }
        }

        if (ValueClass.Playing)
        {
            // Translation
            // Apply translation.
            gameObject.transform.Translate(new Vector3(HorizontalSpeed, YAxisMovement, VerticalSpeed));
        }
<<<<<<< HEAD
        else
        {
            if (transform.position != ValueClass.ResetPoint.transform.position)
            {
                //Go back to center.
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, ValueClass.ResetPoint.transform.position, ValueClass.ReturnSpeed * Time.deltaTime);
            }
        }
=======
>>>>>>> parent of c32c382... PrototypeDone
    }
}
