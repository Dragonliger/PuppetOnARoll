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
                GoalGovernor.GoalMet(11, true, 12, "Place the cucumber on the cutting board", false);
            }
            if(collision.gameObject.CompareTag("Cucumber"))
            {
                GoalGovernor.GoalMet(12, true, 13, "You win", true);
            }
        }

    }
}
