using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabbyKill : MonoBehaviour {

    public Values ValueClass;
    public GameObject Instantiator;
    public float CuttingCountdown = 0.5f;
    public GameObject RootIngredient;
    public GameObject IngredientBody;
    public GameObject PrefabCrab;
    public GameObject ShellAppearer;

    private float Countdown;
    private bool invoked = false;

	// Use this for initialization
	void Start () {
        Countdown = CuttingCountdown;
	}
	
	// Update is called once per frame
	void Update () {
        DestroyBelowCullingHeight();
        if(Countdown > 0.01f)
        {
            Countdown -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<ExplosiveTeeth>() != null)
        {
            //get slightly cut
            Cut();
        }
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
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<CrabbyAI>().enabled = false;
        RootIngredient.GetComponent<CrabbyIngredient>().ActivateCollisions();
        List<CrabbyIngredient> Lista = new List<CrabbyIngredient>();
        Lista.AddRange(RootIngredient.GetComponent<Transform>().GetComponentsInChildren<CrabbyIngredient>());
        foreach(CrabbyIngredient Pieza in Lista)
        {
            Pieza.ActivateCollisions();
        }
        RootIngredient.GetComponent<Transform>().DetachChildren();
        if (invoked == false)
        {
            GameObject TempShell = Instantiate(PrefabCrab, ShellAppearer.transform);
            TempShell.GetComponent<CrabbyIngredient>().Instantiator = RootIngredient.GetComponent<CrabbyIngredient>().Instantiator;
            TempShell.GetComponent<CrabbyIngredient>().ValueClass = RootIngredient.GetComponent<CrabbyIngredient>().ValueClass;
            invoked = true;
            TempShell.GetComponent<CrabbyIngredient>().enabled = true;
            TempShell.transform.parent = null;
        }
        Destroy(RootIngredient);
        Destroy(IngredientBody);
    }

}
