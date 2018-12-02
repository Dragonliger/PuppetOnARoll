using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabbyAI : MonoBehaviour {

    public float Speed = 5.0f;
    public float TurningSpeed = 30.0f;
    public LayerMask whatIsWall;
    public float maxDistFromWall = 0.0f;
    public int randomCountdown = 5;
    public float bumper = 0.5f;
    public float FrontWallLimit = 0.0f;
    public float Roof = 1.15f;
    public GameObject PokingStick;

    private int Counter = 0;
    private Rigidbody RBody;
    private Vector3 moveDir;
    private Quaternion TargetRotation = Quaternion.identity;
    
// Use this for initialization
    void Start () {
        RBody = GetComponent<Rigidbody>();
        moveDir = ChooseDirection();
        transform.rotation = Quaternion.LookRotation(moveDir);
        Counter = randomCountdown;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 TempSpeed = -transform.up * Speed;
        RBody.velocity = new Vector3(TempSpeed.x, ((RBody.velocity.y *bumper) + TempSpeed.y), TempSpeed.z);
        Counter--;
        if (Counter == 0)
        {
            Counter = randomCountdown;
            moveDir = ChooseDirection();
            SetBlendedEulerAngles(moveDir);
        }



        if (Physics.Raycast(transform.position, -transform.up, maxDistFromWall, whatIsWall, QueryTriggerInteraction.Collide) && (Counter == 0))
        {
            moveDir = transform.up;
            SetBlendedEulerAngles(moveDir);
            //got here
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, TurningSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(-90.0f, transform.eulerAngles.y, transform.eulerAngles.z);
        if(PokingStick.transform.position.z <= FrontWallLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, FrontWallLimit);
        }
        if(PokingStick.transform.position.y >= Roof)
        {
            transform.position = new Vector3(transform.position.x, Roof, transform.position.z);
        }
    }

    Vector3 ChooseDirection()
    {
        System.Random ran = new System.Random();
        int i = ran.Next(0, 8);
        Vector3 temp = new Vector3(-90.0f, i*45.0f, 0.0f);

        return temp;
    }

    public void WakeUp()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        gameObject.GetComponent<Collider>().enabled = true;
    }

    public void SetBlendedEulerAngles(Vector3 angles)
    {
#pragma warning disable CS0618 // Type or member is obsolete
        TargetRotation = Quaternion.EulerAngles(angles);
#pragma warning restore CS0618 // Type or member is obsolete
    }

}
