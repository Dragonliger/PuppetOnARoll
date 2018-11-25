using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour {

    public GameObject Instantiator;
    public GameObject Prefab;
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
        if (gameObject.transform.position.y <= CullingHeight)
        {
            transform.position = Instantiator.transform.position;
            transform.eulerAngles = new Vector3(0.0f, 0.0f, 24.0f);
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //GameObject TempObject = Instantiate(Prefab, Instantiator.transform.position, Quaternion.identity);
            //TempObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 24.0f);
            //TempObject.GetComponent<Tool>().ValueClass = ValueClass;
            //TempObject.GetComponent<Tool>().Instantiator = Instantiator;
            //TempObject.GetComponent<Tool>().Prefab = Prefab;
            //Destroy(gameObject);
        }
    }

}
