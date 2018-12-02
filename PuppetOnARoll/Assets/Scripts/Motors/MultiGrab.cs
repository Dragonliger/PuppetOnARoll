using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiGrab : MonoBehaviour {

    public Values ValueClass;
    public GameStates GameGovernor;
    public GameObject GrabPoint;
    public Animator HandAnimator;

    private List<GameObject> Touching = new List<GameObject>();
    private float TemporaryMinHeight;
    private bool Releaseable = false;

	// Use this for initialization
	void Start () {
        TemporaryMinHeight = ValueClass.MinimumHeight;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Grab") && GameGovernor.isPlaying())
        {
            HandAnimator.SetBool("Close", true);
            Releaseable = false;
        }
        if(!Input.GetButton("Grab"))
        {
            Releaseable = true;
        }
        // If the grab button is released and no object was grabbed open the hand.
        if (Input.GetButtonUp("Grab") && GameGovernor.isPlaying() && (Touching.Count == 0))
        {
            HandAnimator.SetBool("Close", false);
            HandAnimator.SetBool("Chainsaw", false);
            HandAnimator.SetBool("Tool", false);
        }
        if (Input.GetButtonDown("Release") && GameGovernor.isPlaying() && Releaseable)
        {
            foreach(GameObject Grabbed in Touching)
            {
                Grabbed.GetComponent<Rigidbody>().isKinematic = false;
                Grabbed.GetComponent<Rigidbody>().useGravity = true;
                if (Grabbed.GetComponent<Chainsaw>() != null)
                {
                    Grabbed.GetComponent<Chainsaw>().ToolDropped();
                    //ValueClass.MinimumHeight = TemporaryMinHeight;
                }
                Grabbed.transform.SetParent(null);
            }
            Touching.Clear();
            HandAnimator.SetBool("Close", false);
            HandAnimator.SetBool("Chainsaw", false);
            HandAnimator.SetBool("Tool", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If the hand is in collision with an object and Grab is pressed
        if(Input.GetButton("Grab"))
        {
            if(collision.gameObject.tag == "Tool")
            {
                //You can only hold one tool at a time.
                if(Touching.Count == 0)
                {
                    Touching.Add(collision.gameObject);
                    HandAnimator.SetBool("Tool", true);
                    if (collision.gameObject.GetComponent<Chainsaw>() != null)
                    {
                        HandAnimator.SetBool("Chainsaw", true);
                        Touching[0].transform.position = GrabPoint.transform.position;
                        Touching[0].transform.SetParent(GrabPoint.transform);
                        collision.gameObject.GetComponent<Chainsaw>().ToolGrabbed();
                        ValueClass.MinimumHeight = ValueClass.ToolMinimumHeight;
                    }
                    else
                    {
                        Touching[0].GetComponent<Rigidbody>().isKinematic = true;
                        Touching[0].GetComponent<Rigidbody>().useGravity = false;
                        Touching[0].transform.position = GrabPoint.transform.position;
                        Touching[0].transform.SetParent(GrabPoint.transform);
                    }
                }
            }
            else
            {
                Touching.Add(collision.gameObject);
                if(Touching[0].CompareTag(collision.gameObject.tag))
                {
                    //If it's only grabbing the same kind of object it's fine.
                    collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    collision.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    collision.gameObject.transform.SetParent(GrabPoint.transform);
                }
                else
                {
                    //If it's a different kind of object, remove it.
                    Touching.Remove(collision.gameObject);
                }
            }
        }
    }
}
