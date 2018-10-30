using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour {

    public Values ValueClass;
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
            ValueClass.Decrease(gameObject.tag);
            Destroy(gameObject);
        }
    }
}
