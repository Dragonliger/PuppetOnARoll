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

    private void OnCollisionEnter(Collision collision)
    {
        if (GameGovernor.isPlaying())
        {
            if(collision.gameObject.CompareTag("Rice"))
            {
                GoalGovernor.GoalMet(0, true, 1, "Grab the chainsaw", false);
            }
            if(collision.gameObject.CompareTag("Cucumber"))
            {
                GoalGovernor.GoalMet(3, true, 4, "You win", true);
            }
        }

    }
}
