using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour {

    public GameObject GrabPoint;
    public Animator HandAnimator;
    public bool difficult = false;
    public bool playing = true;

    private bool CanGrab = true;
    private GameObject Touching = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ((Touching != null) && Input.GetButtonUp("Jump") && playing)
        {
            Touching.GetComponent<Rigidbody>().isKinematic = false;
            Touching.GetComponent<Rigidbody>().useGravity = true;
            Touching.transform.SetParent(null);
            Touching = null;
        }
        if (Input.GetButton("Jump") && playing)
        {
            HandAnimator.SetBool("Close", true);
            if(Touching == null && difficult)
            {
                CanGrab = false;
            }
        }
        else
        {
            HandAnimator.SetBool("Close", false);
            CanGrab = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(Input.GetButton("Jump") && (Touching == null) && CanGrab && playing)
        {
            Touching = collision.gameObject;
            Touching.GetComponent<Rigidbody>().isKinematic = true;
            Touching.GetComponent<Rigidbody>().useGravity = false;
            //Touching.transform.position = GrabPoint.transform.position;
            Touching.transform.SetParent(GrabPoint.transform);

        }
    }
}
