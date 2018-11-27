﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStates : MonoBehaviour {

    public GameObject TimerText;
    //public GameObject PanelText;
    public GameObject VictoryScreenPrefab;
    public GameObject GameOverScreenPrefab;
    public bool Playing = true;
    public GameObject RecipeInstructions;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StopPlay()
    {
        gameObject.GetComponent<Values>().Playing = false;
        TimerText.SetActive(false);
        //PanelText.SetActive(false);
        Playing = false;
    }

    public void StartPlay()
    {
        gameObject.GetComponent<Values> ().Playing = true;
        TimerText.SetActive(true);
        //PanelText.SetActive(true);
        Playing = true;
    }

    public void GameOverScreen(string reason)
    {
        StopPlay();
        GameOverScreenPrefab.GetComponent<DumbUpdate>().GameOverText = reason;
        GameOverScreenPrefab.SetActive(true);
    }

    public void VictoryScreen()
    {
        StopPlay();
        VictoryScreenPrefab.SetActive(true);
        RecipeInstructions.SetActive(false);
    }

    public bool isPlaying()
    {
        return Playing;
    }
}
