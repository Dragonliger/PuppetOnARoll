using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabbyIngredient : MonoBehaviour {

    public Values ValueClass;
    public GameObject Instantiator;
    public bool Active = false;

    private float Countdown = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DestroyBelowCullingHeight();
        if (Countdown >= 0.01f)
        {
            Countdown -= Time.deltaTime;
        }
    }

    public void ActivateCollisions()
    {
        Rigidbody TempRigidBody = gameObject.GetComponent<Rigidbody>();
        TempRigidBody.isKinematic = false;
        TempRigidBody.useGravity = true;
        gameObject.GetComponent<Collider>().enabled = true;
        Active = true;
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

    public void Cut()
    {
        if (Countdown < 0.01f)
        {
            if (transform.childCount > 0)
            {
                foreach (Transform Child in transform)
                {
                    CrabbyIngredient tempIng = Child.gameObject.GetComponent<CrabbyIngredient>();
                    if (tempIng != null)
                    {
                        tempIng.ActivateCollisions();
                    }
                }
                transform.DetachChildren();
                Destroy(gameObject);
            }
            Countdown = ValueClass.CuttingCountDown + .01f;
        }
    }
}
