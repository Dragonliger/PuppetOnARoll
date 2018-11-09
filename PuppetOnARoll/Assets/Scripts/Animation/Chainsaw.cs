using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour {

    public Animator ChainsawAnimator;
    public List<Collider> SawTeeth = new List<Collider>();

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void ToolGrabbed()
    {
        ChainsawAnimator.SetBool("Grabbed", true);
        foreach(Collider Tooth in SawTeeth)
        {
            Tooth.enabled = true;
        }
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.transform.eulerAngles = new Vector3(-1.5f, 88.0f, -89.0f);
    }

    public void ToolDropped()
    {
        ChainsawAnimator.SetBool("Grabbed", false);
        foreach (Collider Tooth in SawTeeth)
        {
            Tooth.enabled = false;
        }
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Collider>().enabled = true;
    }
}
