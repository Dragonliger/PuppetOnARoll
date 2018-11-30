using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateGrab : MonoBehaviour {

    public Values ValueClass;
    public GameStates GameGovernor;
    public GameObject GrabPoint;
    public Animator HandAnimator;
    public float GrabReset = 0.5f;

    private bool CanGrab = true;
    private GameObject Touching = null;
    private float TemporaryMinHeight;
    private bool WasUp = false;

	// Use this for initialization
	void Start () {
        TemporaryMinHeight = ValueClass.MinimumHeight;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonUp("Grab") && GameGovernor.isPlaying())
        {
            WasUp = true;
        }
        // If the hand is not holding something
        if (CanGrab)
        {
            // Close the hand upon grab button.
            if (Input.GetButtonDown("Grab") && GameGovernor.isPlaying())
            {
                ValueClass.GoalGovernor.GoalMet(1, true, 2, "Take the lid off the rice cooker", false);
                HandAnimator.SetBool("Close", true);
            }
            // If the grab button is released and no object was grabbed open the hand.
            if(Input.GetButtonUp("Grab") && GameGovernor.isPlaying())
            {
                if (WasUp)
                {
                    HandAnimator.SetBool("Close", false);
                    HandAnimator.SetBool("Chainsaw", false);
                    HandAnimator.SetBool("Tool", false);
                }
            }
        }
        else
        {
            if(Input.GetButtonDown("Release") && GameGovernor.isPlaying() && WasUp)
            {
                Touching.GetComponent<Rigidbody>().isKinematic = false;
                Touching.GetComponent<Rigidbody>().useGravity = true;
                if (Touching.gameObject.GetComponent<Chainsaw>() != null)
                {
                    Touching.gameObject.GetComponent<Chainsaw>().ToolDropped();
                    ValueClass.MinimumHeight = TemporaryMinHeight;
                }
                Touching.transform.SetParent(null);
                HandAnimator.SetBool("Close", false);
                HandAnimator.SetBool("Chainsaw", false);
                HandAnimator.SetBool("Tool", false);
                Touching = null;
                Invoke("MakeGrabbable",GrabReset);
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        // If the hand is in collision with an object and Grab is pressed
        if(Input.GetButton("Grab") && GameGovernor.isPlaying() && CanGrab)
        {
            ValueClass.GoalGovernor.GoalMet(1, true, 2, "Take the lid off the rice cooker", false);
            CanGrab = false;
            Touching = collision.gameObject;
            if (collision.gameObject.tag == "Tool")
            {
                HandAnimator.SetBool("Tool", true);
                if (collision.gameObject.GetComponent<Chainsaw>() != null)
                {
                    HandAnimator.SetBool("Chainsaw", true);
                    Touching.transform.position = GrabPoint.transform.position;
                    Touching.transform.SetParent(GrabPoint.transform);
                    collision.gameObject.GetComponent<Chainsaw>().ToolGrabbed();
                    ValueClass.MinimumHeight = ValueClass.ToolMinimumHeight;
                }
                else
                {
                    Touching.GetComponent<Rigidbody>().isKinematic = true;
                    Touching.GetComponent<Rigidbody>().useGravity = false;
                    Touching.transform.position = GrabPoint.transform.position;
                    Touching.transform.SetParent(GrabPoint.transform);
                }
            }
            else
            {
                Touching.GetComponent<Rigidbody>().isKinematic = true;
                Touching.GetComponent<Rigidbody>().useGravity = false;
                //Touching.transform.position = GrabPoint.transform.position;
                Touching.transform.SetParent(GrabPoint.transform);
            }
            WasUp = false;
            if(collision.gameObject.tag == "Lid")
            {
                ValueClass.GoalGovernor.GoalMet(6, true, 7, "Put the rice into the rice cooker", false);
            }
        }
    }

    private void MakeGrabbable()
    {
        CanGrab = true;
    }
}
