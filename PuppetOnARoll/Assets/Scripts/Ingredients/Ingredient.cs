using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour {

    public Values ValueClass;
<<<<<<< HEAD
    public GameObject Instantiator;

=======
>>>>>>> parent of c32c382... PrototypeDone
    private float CullingHeight;

	// Use this for initialization
	void Start () {
        CullingHeight = ValueClass.CullingHeight;
	}
	
	// Update is called once per frame
	void Update () {
        DestroyBelowCullingHeight();
	}

    void DestroyBelowCullingHeight()
    {
        if(gameObject.transform.position.y <= CullingHeight)
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
}
