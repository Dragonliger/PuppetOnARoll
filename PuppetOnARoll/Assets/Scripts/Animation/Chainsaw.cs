using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour {

    public Animator ChainsawAnimator;
    public List<Collider> SawTeeth = new List<Collider>();
<<<<<<< HEAD
    public Values ValueClass;
    public GameObject ChainsawProducer;
    public GameObject Prefab;
    public float changeFrontWall;
    private AudioSource Sonido;
    private float frontWall;

    private float CullingHeight;

    // Use this for initialization
    void Start () {
        CullingHeight = ValueClass.CullingHeight;
        Sonido = gameObject.GetComponent<AudioSource>();
        frontWall = ValueClass.FrontInvisiwall;
=======

    // Use this for initialization
    void Start () {

>>>>>>> parent of c32c382... PrototypeDone
    }

    // Update is called once per frame
    void Update () {
<<<<<<< HEAD

    }
=======
>>>>>>> parent of c32c382... PrototypeDone

    }

    public void ToolGrabbed()
    {
        ChainsawAnimator.SetBool("Grabbed", true);
        foreach(Collider Tooth in SawTeeth)
        {
            Tooth.enabled = true;
        }
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.transform.eulerAngles = new Vector3(-1.5f, 88.0f, -89.0f);
        ValueClass.FrontInvisiwall = changeFrontWall;
        Sonido.Play();
    }

    public void ToolDropped()
    {
        ChainsawAnimator.SetBool("Grabbed", false);
        foreach (Collider Tooth in SawTeeth)
        {
            Tooth.enabled = false;
        }
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Collider>().enabled = true;
        ValueClass.FrontInvisiwall = frontWall;
        Sonido.Stop();
    }
}
