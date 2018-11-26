using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalManager : MonoBehaviour {

    public GameStates GameGovernor;
    public Text GoalText;
    public Toggle GoalCheckbox;

    private int GoalsAchieved = 0;
    private int GoalsFailed = 0;
    private int CurrentGoalCode = 0;
    private string GNextGoalText;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoalMet(int GoalIndex, bool GoalAchieved, int NextGoalIndex, string NextGoalText, bool EndGame)
    {
        if(GoalIndex == CurrentGoalCode)
        {
            if(GoalAchieved)
            {
                GoalsAchieved++;
            }
            else
            {
                GoalsFailed++;
            }
            CurrentGoalCode = NextGoalIndex;
            GNextGoalText = NextGoalText;
            Invoke("ChangeGoalText", 2);
            if(EndGame)
            {
                //trigger victory screen er something.
            }
        }
    }

    public void ChangeGoalText()
    {
        GoalText.text = GNextGoalText;

    }
}
