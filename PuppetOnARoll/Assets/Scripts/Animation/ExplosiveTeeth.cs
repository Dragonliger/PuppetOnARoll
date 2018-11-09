using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveTeeth : MonoBehaviour {

    public Values ValueSheet;
    private float force;

	// Use this for initialization
	void Start () {
        force = ValueSheet.ChainsawTeethForce;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody Explody = collision.gameObject.GetComponent<Rigidbody>();
        if(Explody != null)
        {
            Vector3 StrengthDirection = (gameObject.transform.position - collision.transform.position)*force;
            Explody.AddForce(StrengthDirection, ForceMode.Acceleration);
        }
    }
}
