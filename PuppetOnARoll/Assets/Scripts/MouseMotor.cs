using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMotor : MonoBehaviour
{
    public float speed = 12.0f;
    public float SpatialModifier = 1.0f;
    public float DownSpeed = 1.0f;
    public float UpSpeed = 2.0f;
    public float DefaultHeight = 6.11f;
    public float MinimumHeight = 2.1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Mouse X");
        float HorizontalSpeed = HorizontalInput * speed * Time.deltaTime * SpatialModifier;
        float VerticalInput = Input.GetAxis("Mouse Y");
        float VerticalSpeed = VerticalInput * speed * Time.deltaTime * SpatialModifier;
        float YAxisMovement = 0.0f;
        float YPosition = gameObject.transform.position.y;

        if (Input.GetButton("Fire1"))
        {
            if (YPosition > MinimumHeight)
            {
                YAxisMovement = -1.0f * DownSpeed * Time.deltaTime;
                float Difference = YPosition - MinimumHeight;
                if (-YAxisMovement > Difference)
                {
                    YAxisMovement = Difference * -1.0f;
                }
            }

        }
        else if (gameObject.transform.position.y < DefaultHeight)
        {
            YAxisMovement = 1.0f * UpSpeed * Time.deltaTime;
            float Difference = DefaultHeight - YPosition;
            if (YAxisMovement > Difference)
            {
                YAxisMovement = Difference;
            }
        }

        gameObject.transform.Translate(new Vector3(HorizontalSpeed, YAxisMovement, VerticalSpeed));
    }
}
