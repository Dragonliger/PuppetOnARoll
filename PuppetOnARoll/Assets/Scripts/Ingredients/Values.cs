using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Values : MonoBehaviour {

    public float CullingHeight = -1.0f;
    public GameStates GameGovernor;
    public float ChainsawTeethForce = 1.0f;
    public float ToolMinimumHeight = 2.0f;
    public float CuttingCountDown = 1.0f;

    //Legacy counters, consider deleting.
    int BrownCylinders = 10;
    int GreenSpheres = 5;
    int BlueCubes = 12;
    int MegaBrownCylinders = 1;
    int MegaBlueCubes = 1;
    //int MegaGreenSpheres = 0;


    //MouseFollowMotor Values
    public float speed = 10.0f;
    public float DragSpeed = 3.0f;
    public float DownSpeed = 16.0f;
    public float UpSpeed = 18.0f;
    public float DefaultHeight = 6.11f;
    public float MinimumHeight = 2.6f;
    public float LeftInvisiwall = -18.0f;
    public float RightInvisiwall = 18.0f;
    public float FrontInvisiwall = 20.8f;
    public float BackInvisiwall = 0.0f;
    public bool Playing = true;
    public GameObject ResetPoint;
    public float ReturnSpeed = 6.0f;

    public void Decrease(string Tag)
    {
        // Decrease BlueCubes counter.
        if (Tag == "BlueCube")
        {
            BlueCubes--;
            if (BlueCubes < 1)
            {
                // Launch Game Over.
                GameGovernor.GameOverScreen("Not enough ingredients.");
            }
        }
        // Decrease GreenSpheres counter.
        else if (Tag == "GreenSphere")
        {
            GreenSpheres--;
            if (GreenSpheres < 1)
            {
                // Launch Game Over.
                GameGovernor.GameOverScreen("Not enough ingredients.");
            }
        }
        // Decrease BrownCylinders counter.
        else if (Tag == "BrownCylinders")
        {
            BrownCylinders--;
            if (BrownCylinders < 1)
            {
                // Launch Game Over.
                GameGovernor.GameOverScreen("Not enough ingredients.");
            }
        }
        else if(Tag == "MegaBlueCube")
        {
            MegaBlueCubes--;
            if (MegaBlueCubes < 1)
            {
                // Launch Game Over.
                GameGovernor.GameOverScreen("Not enough ingredients.");
            }
        }
        else if (Tag == "MegaBrownCylinder")
        {
            MegaBrownCylinders--;
            if (MegaBrownCylinders < 1)
            {
                // Launch Game Over.
                GameGovernor.GameOverScreen("Not enough ingredients.");
            }
        }

    }
}
