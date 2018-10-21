using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMotor : MonoBehaviour {
    public float speed = 4.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float HorizontalSpeed = HorizontalInput * speed * Time.deltaTime;
        float VerticalInput = Input.GetAxis("Vertical");
        float VerticalSpeed = VerticalInput * speed * Time.deltaTime;

        gameObject.transform.Translate(new Vector3(HorizontalSpeed, 0.0f, VerticalSpeed));
	}
}
