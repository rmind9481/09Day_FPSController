using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnShot : MonoBehaviour {

    public Transform tran;
    public GameObject shell;
    float power = 200f;
    Rigidbody rb;

	// Use this for initialization
	void Start () {



        
	}
	
	// Update is called once per frame
	void Update () {

        


        if (Input.GetButton("Fire1"))
        {   

            var onshot = Instantiate(shell, tran.position, Quaternion.identity);
            rb = onshot.GetComponent<Rigidbody>();
           // rb.AddForce(transform.right * power);
            rb.AddForce(transform.right* Random.Range(100f, 200f));
            rb.useGravity = true;
            
            Destroy(onshot, 1f);
            //Invoke
        }
    }


   
}
