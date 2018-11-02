using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    // Time in seconds assigned for level.
    public float TimerStart = 180.0f;
    public Text UITimer;
    public GameStates GameGovernor;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (TimerStart > 1)
        {
            TimerStart -= Time.deltaTime;
            int minutes = Mathf.RoundToInt(TimerStart / 60) - 1;
            int seconds = Mathf.RoundToInt(TimerStart % 60);
            UITimer.text = "Time left: " + minutes + ":" + seconds;
        }
        else
        {
            //Trigger GameOver
            GameGovernor.GameOverScreen("Timeover!");
        }
    }
}
