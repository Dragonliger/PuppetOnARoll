using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabbyWakey : MonoBehaviour {

    public CrabbyAI CrabAI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void WakeyCrabby()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Animator>().SetBool("Alive", true);
        gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        gameObject.transform.position = new Vector3(transform.position.x, 1.67f, transform.position.z);
        CrabAI.enabled = true;
        CrabAI.WakeUp();
    }
}
