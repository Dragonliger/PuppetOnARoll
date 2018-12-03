using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

    public GameStates GameGovernor;
    //    public List<Text> RecipeList;
    //    public List<string> IngredientsList;
    public GoalManager GoalGovernor;

    //    private List<bool> Done = new List<bool>();
    //    int index = 0;

    // Use this for initialization
    void Start()
    {
        //     for (int i = 0; i < RecipeList.Count; i++)
        //     {
        //        Done.Add(false);
        //     }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay(Collision collision)
    {
        if (GameGovernor.isPlaying())
        {
            if(collision.gameObject.CompareTag("CookedRice"))
            {
                GoalGovernor.GoalMet(9, true, 10, "Cut the cucumber", false);
            }
            if(collision.gameObject.CompareTag("Cucumber"))
            {
                GoalGovernor.GoalMet(11, true, 12, "You win", true);
            }
            if(collision.gameObject.CompareTag("Crab"))
            {
                GoalGovernor.GoalMet(8, true, 9, "Put the cooked rice on the cutting board", false);
            }
        }

    }
}
