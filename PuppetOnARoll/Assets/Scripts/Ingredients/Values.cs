using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Values : MonoBehaviour {

    public float CullingHeight = -1.0f;
    public int BrownCylinders = 10;
    public int GreenSpheres = 5;
    public int BlueCubes = 12;

    public void Decrease(string Tag)
    {
        // Decrease BlueCubes counter.
        if (Tag == "BlueCube")
        {
            BlueCubes--;
            if (BlueCubes < 1)
            {
                // Launch Game Over.
            }
        }
        // Decrease GreenSpheres counter.
        else if (Tag == "GreenSphere")
        {
            GreenSpheres--;
            if (GreenSpheres < 1)
            {
                // Launch Game Over.
            }
        }
        // Decrease BrownCylinders counter.
        else if (Tag == "BrownCylinders")
        {
            BrownCylinders--;
            if (BrownCylinders < 1)
            {
                // Launch Game Over.
            }
        }

    }
}
