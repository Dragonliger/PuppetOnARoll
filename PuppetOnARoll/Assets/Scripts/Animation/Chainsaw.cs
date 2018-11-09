using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour {


    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void ToolGrabbed()
    {
        gameObject.GetComponent<Animator>().SetBool(0, true);
    }

    public void ToolDropped()
    {
        gameObject.GetComponent<Animator>().SetBool(0, false);
    }
}
