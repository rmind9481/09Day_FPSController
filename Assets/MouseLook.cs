using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    public float sensitivity = 100f;

    float rotationX;
    float rotationY;


    GameObject character;


	// Use this for initialization
	void Start () {
        character = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        rotationX += v * sensitivity * Time.deltaTime;
        rotationY += h * sensitivity * Time.deltaTime;

        Debug.Log(rotationX);

        if (rotationX > 45f)
        {
            rotationX = 45f;

        }
        if (rotationX < -20f)
        {
            rotationX = -20f;
        }


        transform.localRotation = Quaternion.AngleAxis(-rotationX, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(rotationY, character.transform.up);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }


	}
}
