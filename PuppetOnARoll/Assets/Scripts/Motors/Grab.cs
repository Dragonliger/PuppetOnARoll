﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour {

    public Values ValueScript;
    public MouseFollowMotor PlayerMotor;
    public GameObject GrabPoint;
    public Animator HandAnimator;
    public bool difficult = false;
    public bool playing = true;

    private bool CanGrab = true;
    private GameObject Touching = null;
    private float TemporaryMinHeight;

	// Use this for initialization
	void Start () {
        TemporaryMinHeight = PlayerMotor.MinimumHeight;
	}
	
	// Update is called once per frame
	void Update () {
        if ((Touching != null) && Input.GetButtonUp("Jump") && playing)
        {
            Touching.GetComponent<Rigidbody>().isKinematic = false;
            Touching.GetComponent<Rigidbody>().useGravity = true;
            if(Touching.gameObject.GetComponent<Chainsaw>() != null)
            {
                Touching.gameObject.GetComponent<Chainsaw>().ToolDropped();
                PlayerMotor.MinimumHeight = TemporaryMinHeight;
            }
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
            HandAnimator.SetBool("Chainsaw", false);
            HandAnimator.SetBool("Tool", false);
            CanGrab = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {

        if (Input.GetButton("Jump") && (Touching == null) && CanGrab && playing)
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
                    PlayerMotor.MinimumHeight = ValueScript.ToolMinimumHeight;
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
