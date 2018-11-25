using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    // Time in seconds assigned for level.
    //public float TimerStart = 180.0f;
    public Text UITimer;
    public GameStates GameGovernor;
    private Values ValueClass;

    // Use this for initialization
    void Start () {
        ValueClass = gameObject.GetComponent<Values>();
	}
	
	// Update is called once per frame
	void Update () {


        if (ValueClass.Playing)
        {
            if (ValueClass.TimerStart > 1)
            {
                ValueClass.TimerStart -= Time.deltaTime;
                int minutes = Mathf.FloorToInt(ValueClass.TimerStart / 60);
                if (minutes < 0)
                {
                    minutes = minutes - 1;
                }
                string seconds = Mathf.RoundToInt(ValueClass.TimerStart % 60).ToString();
                if(seconds.Length < 2)
                {
                    seconds = "0" + seconds;
                }
                UITimer.text = "Time left: " + minutes + ":" + seconds;
            }
            else
            {
                //Trigger GameOver
                GameGovernor.GameOverScreen("Timeover!");
            }
        }
    }
}
