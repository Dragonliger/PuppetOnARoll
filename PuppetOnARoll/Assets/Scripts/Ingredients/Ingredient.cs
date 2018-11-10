using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour {

    public Values ValueClass;

    private float CullingHeight;
    private float Countdown;

	// Use this for initialization
	void Start () {
        CullingHeight = ValueClass.CullingHeight;
        Countdown = 0;
	}

    // Update is called once per frame
    void Update()
    {
        DestroyBelowCullingHeight();
        if (Countdown >= 0.01f)
        {
            Countdown -= (1.0f * Time.deltaTime);
        }
    }

    void DestroyBelowCullingHeight()
    {
        if(gameObject.transform.position.y <= CullingHeight)
        {
            ValueClass.Decrease(gameObject.tag);
            Destroy(gameObject);
        }
    }

    public bool IsIngredient()
    {
        return true;
    }

    public void Cut()
    {
        if (Countdown < 0.01f)
        {
            if (transform.childCount > 0)
            {
                foreach (Transform Child in transform)
                {
                    Child.gameObject.GetComponent<Ingredient>().ActivateCollisions();
                }
                transform.DetachChildren();
                Destroy(gameObject);
            }
            Countdown = ValueClass.CuttingCountDown + .01f;
        }
    }

    public void ActivateCollisions()
    {

            Rigidbody TempRigidBody = gameObject.GetComponent<Rigidbody>();
            TempRigidBody.isKinematic = false;
            TempRigidBody.useGravity = true;
            gameObject.GetComponent<Collider>().enabled = true;

    }
}
