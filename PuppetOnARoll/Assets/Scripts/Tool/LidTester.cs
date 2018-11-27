using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidTester : MonoBehaviour {

    private bool Lid = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Lid"))
        {
            Lid = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Lid"))
        {
            Lid = false;
        }
    }

    public bool isLidOn()
    {
        return Lid;
    }
}
