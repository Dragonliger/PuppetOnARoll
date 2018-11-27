using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceCooker : MonoBehaviour {

    public LidTester Lidder;
    public float timer = 5.0f;
    public Material cookedRiceMat;

    private List<GameObject> Rices = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionStay(Collision collision)
    {
        GameObject Rice = collision.gameObject;
        if(Rice.CompareTag("Rice"))
        {
            Rices.Add(Rice);
            if (Lidder.isLidOn())
            {
                startCooking();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject Rice = collision.gameObject;
        if (Rice.CompareTag("Rice"))
        {
            Rices.Remove(Rice);
        }
    }

    void startCooking()
    {
        Invoke("cook", timer);
    }

    void cook()
    {
        if(Lidder.isLidOn())
        {
            foreach(GameObject rice in Rices)
            {
                rice.tag = "CookedRice";
                rice.GetComponent<Renderer>().material = cookedRiceMat;
            }
        }
    }
}
