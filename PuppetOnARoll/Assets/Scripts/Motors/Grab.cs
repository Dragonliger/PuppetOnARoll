using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour {

<<<<<<< HEAD
    public Values ValueClass;
=======
>>>>>>> parent of c32c382... PrototypeDone
    public GameObject GrabPoint;
    public Animator HandAnimator;
    public bool difficult = false;
    public bool playing = true;

    private bool CanGrab = true;
    private GameObject Touching = null;

	// Use this for initialization
	void Start () {
<<<<<<< HEAD
        TemporaryMinHeight = ValueClass.MinimumHeight;
=======
		
>>>>>>> parent of c32c382... PrototypeDone
	}
	
	// Update is called once per frame
	void Update () {
        if ((Touching != null) && Input.GetButtonUp("Grab") && playing)
        {
            Touching.GetComponent<Rigidbody>().isKinematic = false;
            Touching.GetComponent<Rigidbody>().useGravity = true;
            if(Touching.gameObject.GetComponent<Chainsaw>() != null)
            {
                Touching.gameObject.GetComponent<Chainsaw>().ToolDropped();
<<<<<<< HEAD
                ValueClass.MinimumHeight = TemporaryMinHeight;
=======
>>>>>>> parent of c32c382... PrototypeDone
            }
            Touching.transform.SetParent(null);
            Touching = null;
        }
        if (Input.GetButton("Grab") && playing)
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

        if (Input.GetButton("Grab") && (Touching == null) && CanGrab && playing)
        {
            Touching = collision.gameObject;
            if (collision.gameObject.tag == "Tool")
            {
                HandAnimator.SetBool("Tool", true);
                if(collision.gameObject.GetComponent<Chainsaw>() != null)
                {
                    HandAnimator.SetBool("Chainsaw", true);
                    Touching.transform.position = GrabPoint.transform.position;
                    Touching.transform.SetParent(GrabPoint.transform);
                    collision.gameObject.GetComponent<Chainsaw>().ToolGrabbed();
<<<<<<< HEAD
                    ValueClass.MinimumHeight = ValueClass.ToolMinimumHeight;
=======
>>>>>>> parent of c32c382... PrototypeDone
                }
            }
            else
            {
                Touching = collision.gameObject;
                Touching.GetComponent<Rigidbody>().isKinematic = true;
                Touching.GetComponent<Rigidbody>().useGravity = false;
                //Touching.transform.position = GrabPoint.transform.position;
                Touching.transform.SetParent(GrabPoint.transform);
            }
        }
    }


}
