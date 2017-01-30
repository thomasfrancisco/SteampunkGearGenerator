using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

    public float sensitivity;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("Mouse Y") != 0)
        {
            transform.eulerAngles += Vector3.left * Input.GetAxis("Mouse Y") * sensitivity;
        }
        if(Input.GetAxis("Mouse X") != 0)
        {
            transform.eulerAngles += Vector3.up * Input.GetAxis("Mouse X") * sensitivity;
        }

        transform.position += Vector3.right * Input.GetAxis("Vertical");
        transform.position += Vector3.back * Input.GetAxis("Horizontal");
		
	}
}
