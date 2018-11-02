using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

    public int Step1BC = 2;
    public int Step2GS = 1;
    public int Step3BC = 3;
    public int Step4GS = 1;
    public Text RecipeList;
    public GameStates GameGovernor;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if ((collision.gameObject.tag == "BrownCylinder") && (Step1BC > 0))
        {
            Destroy(collision.gameObject);
            Step1BC--;
            RecipeList.text = "• " + Step1BC + " Brown Cylinders\n• 1 Green Sphere\n• 3 Blue Boxes\n• 1 Green Sphere";
            if (Step1BC == 0)
            {
                RecipeList.text = "• 1 Green Sphere\n• 3 Blue Boxes\n• 1 Green Sphere";
            }
        }
        else if ((collision.gameObject.tag == "GreenSphere") && (Step2GS > 0))
        {
            Destroy(collision.gameObject);
            Step2GS--;
            RecipeList.text = "• " + Step2GS + " Green Sphere\n• 3 Blue Boxes\n• 1 Green Sphere";
            if (Step2GS == 0)
            {
                RecipeList.text = "• 3 Blue Boxes\n• 1 Green Sphere";
            }
        }
        else if ((collision.gameObject.tag == "BlueCube") && (Step3BC > 0))
        {
            Destroy(collision.gameObject);
            Step3BC--;
            RecipeList.text = "• " + Step3BC + " Blue Boxes\n• 1 Green Sphere";
            if (Step3BC == 0)
            {
                RecipeList.text = "• 1 Green Sphere";
            }
        }
        else if ((collision.gameObject.tag == "GreenSphere") && (Step4GS > 0))
        {
            Destroy(collision.gameObject);
            Step4GS--;
            RecipeList.text = "• " + Step4GS + " Green Sphere";
            if (Step4GS == 0)
            {
                RecipeList.text = "";
                // Victory screen.
                GameGovernor.VictoryScreen();
            }

        }
    }
}
