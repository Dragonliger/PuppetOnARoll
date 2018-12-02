using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveCrab : MonoBehaviour {

    private Animator ThisAnimator;

	// Use this for initialization
	void Start () {
        ThisAnimator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ImAlive()
    {
        ThisAnimator.SetBool("Alive", true);
    }

    public void ImDead()
    {
        ThisAnimator.SetBool("Alive", false);
    }
}
