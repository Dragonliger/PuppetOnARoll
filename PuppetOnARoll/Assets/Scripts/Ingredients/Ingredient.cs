using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour {

    public Values ValueClass;
    public GameObject Instantiator;
    public bool Active = false;
    public GoalManager GoalGovernor;

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
        if((gameObject.transform.position.y <= CullingHeight) && Active)
        {
            // Avoiding ingredientless game over
            //ValueClass.Decrease(gameObject.tag);
            //Destroy(gameObject);
            transform.position = Instantiator.transform.position;
            transform.eulerAngles = new Vector3(0.0f, 0.0f, 24.0f);
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
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
            if(gameObject.CompareTag("Cucumber"))
            {
                GoalGovernor.GoalMet(10, true, 11, "Place the cooked rice on the cutting board", false);
            }
        }
    }

    public void ActivateCollisions()
    {
        Rigidbody TempRigidBody = gameObject.GetComponent<Rigidbody>();
        TempRigidBody.isKinematic = false;
        TempRigidBody.useGravity = true;
        gameObject.GetComponent<Collider>().enabled = true;
        gameObject.GetComponent<Ingredient>().Active = true;
    }
}
