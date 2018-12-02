using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCrab : MonoBehaviour {

    public GameObject CrabRoot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MakeAlive()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        CrabRoot.GetComponent<Collider>().enabled = true;
        CrabRoot.GetComponent<Ingredient>().Active = true;
        CrabRoot.GetComponent<Rigidbody>().useGravity = true;
        CrabRoot.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Animator>().SetBool("Alive", true);
        gameObject.transform.eulerAngles = new Vector3(-90.0f, 0.0f, 0.0f);
    }

}
