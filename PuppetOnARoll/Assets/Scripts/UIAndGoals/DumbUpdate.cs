
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbUpdate : MonoBehaviour {

    public string GameOverText;
    public UnityEngine.UI.Text TexttoChange;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TexttoChange.text = GameOverText;
	}
}
