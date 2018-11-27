using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceCooker : MonoBehaviour {

    public GoalManager GoalGovernor;
    public LidTester Lidder;
    public float timer = 5.0f;
    public Material cookedRiceMat;
    private AudioSource Sonido;
    private bool CookedOnce = false;

    private List<GameObject> Rices = new List<GameObject>();

	// Use this for initialization
	void Start () {
        Sonido = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionStay(Collision collision)
    {
        GameObject Rice = collision.gameObject;
        if(Rice.CompareTag("Rice"))
        {
            GoalGovernor.GoalMet(5, true, 8, "Put the lid on the rice cooker", false);
            Rices.Add(Rice);
        }
        if (Lidder.isLidOn())
        {
            startCooking();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject Rice = collision.gameObject;
        if (Rice.CompareTag("Rice"))
        {
            Rices.Remove(Rice);
            Sonido.Stop();
            CookedOnce = false;
        }
    }

    void startCooking()
    {
        Invoke("cook", timer);
        if (Lidder.isLidOn() && (Rices.Count > 0) && !CookedOnce)
        {
            Sonido.Play();
            CookedOnce = true;
            GoalGovernor.GoalMet(8, true, 9, "Grab the chainsaw", false);  
        }
    }

    void cook()
    {
        if(Lidder.isLidOn() && (Rices.Count > 0))
        {
            foreach(GameObject rice in Rices)
            {
                rice.tag = "CookedRice";
                rice.GetComponent<Renderer>().material = cookedRiceMat;
            }


        }
    }
}
