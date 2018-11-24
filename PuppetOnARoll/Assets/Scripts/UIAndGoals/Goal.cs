using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

    public GameStates GameGovernor;
    public List<Text> RecipeList;
    public List<string> IngredientsList;

    private List<bool> Done = new List<bool>();
    int index = 0;

    // Use this for initialization
    void Start () {
        for (int i = 0; i < RecipeList.Count; i++)
        {
            Done.Add(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (GameGovernor.isPlaying())
        {
            foreach (string IngredientTag in IngredientsList)
            {
                if (collision.gameObject.tag == IngredientTag)
                {
                    foreach (Text Unit in RecipeList)
                    {
                        if (Unit.gameObject.tag == IngredientTag)
                        {
                            // Mark as used.
                            Unit.color = Color.grey;
                            collision.gameObject.tag = "UsedIngredient";
                            Done[index] = true;
                            // Confirm if victory
                            if (!Done.Contains(false))
                            {
                                GameGovernor.VictoryScreen();
                            }
                            index++;
                            IngredientsList.Remove(IngredientTag);
                            break;
                        }
                    }
                }
            }

        }
    }
}
