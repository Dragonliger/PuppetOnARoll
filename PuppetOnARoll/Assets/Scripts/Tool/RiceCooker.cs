using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceCooker : MonoBehaviour {

    public GoalManager GoalGovernor;
    public LidTester Lidder;
    public float timer = 5.0f;
    public Material cookedRiceMat;
    public CrabbyWakey Crabby;
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

    private void OnTriggerStay(Collider collision)
    {
        GameObject Rice = collision.gameObject;
        if(Rice.CompareTag("Rice"))
        {
            GoalGovernor.GoalMet(4, true, 5, "Put the lid on the rice cooker", false);
            Rices.Add(Rice);
        }
        if (Lidder.isLidOn())
        {
            startCooking();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject Rice = other.gameObject;
        if (Rice.CompareTag("Rice"))
        {
            Rices.Remove(Rice);
            Sonido.Stop();
            CookedOnce = false;
        }
    }

    void startCooking()
    {
        if (Lidder.isLidOn() && (Rices.Count > 0) && !CookedOnce)
        {
            Sonido.Play();
            CookedOnce = true;
            Crabby.WakeyCrabby();
            Invoke("cook", timer);
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
