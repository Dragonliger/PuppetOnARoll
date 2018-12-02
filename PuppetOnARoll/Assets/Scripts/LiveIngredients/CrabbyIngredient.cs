using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabbyIngredient : MonoBehaviour {

    public Values ValueClass;
    public GameObject Instantiator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DestroyBelowCullingHeight();
	}

    public void ActivateCollisions()
    {
        Rigidbody TempRigidBody = gameObject.GetComponent<Rigidbody>();
        TempRigidBody.isKinematic = false;
        TempRigidBody.useGravity = true;
        gameObject.GetComponent<Collider>().enabled = true;
        //gameObject.GetComponent<Ingredient>().Active = true;
    }

    void DestroyBelowCullingHeight()
    {
        if (gameObject.transform.position.y <= ValueClass.CullingHeight)
        {
            transform.position = Instantiator.transform.position;
            transform.eulerAngles = new Vector3(-90.0f, 0.0f, 0.0f);
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
