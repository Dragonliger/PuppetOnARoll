using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidTester : MonoBehaviour {

    public GoalManager GoalGovernor;

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
            GoalGovernor.GoalMet(3, true, 4, "Put some rice into the rice cooker", false);
            Lid = false;
        }
    }

    public bool isLidOn()
    {
        return Lid;
    }
}
