using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMotor : MonoBehaviour {
    public float speed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float HorizontalSpeed = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float VerticalSpeed = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        gameObject.transform.Translate(new Vector3(HorizontalSpeed, 0.0f, VerticalSpeed));
	}
}
