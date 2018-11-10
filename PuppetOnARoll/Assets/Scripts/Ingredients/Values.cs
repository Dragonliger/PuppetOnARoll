using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Values : MonoBehaviour {

    public float CullingHeight = -1.0f;
    public int BrownCylinders = 10;
    public int GreenSpheres = 5;
    public int BlueCubes = 12;
    public int MegaBrownCylinders = 1;
    public int MegaGreenSpheres = 0;
    public int MegaBlueCubes = 1;
    public GameStates GameGovernor;
    public float ChainsawTeethForce = 1.0f;
    public float ToolMinimumHeight = 2.0f;
    public float CuttingCountDown = 1.0f;

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
