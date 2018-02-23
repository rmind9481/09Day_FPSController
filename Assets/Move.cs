using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float moveSpeed = 8f;

    public GameObject effect;
    public bool heal = false;

    CharacterController con;
    Vector3 moveDirection = Vector3.zero;

    float jumpSpeed = 8f;
    float gravity = 20f;
    GameObject e;



	// Use this for initialization
	void Start () {
        con = GetComponent<CharacterController>();

		
	}
	
	// Update is called once per frame
	void Update () {
        if (con.isGrounded)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            moveDirection = (new Vector3(h, 0, v)).normalized;

            //transform.LookAt(transform.position + moveDirection);

            moveDirection = transform.TransformDirection(moveDirection);


            moveDirection *= moveSpeed;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
            }

            moveDirection.y -= gravity * Time.deltaTime;
            con.Move(moveDirection * Time.deltaTime);

    

        }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.collider.gameObject.name == "Heal"&& !heal)
        {
             e = Instantiate(effect, transform.Find("FxPos"));
            
            heal = true;
            Invoke("Launch", 2f);

        }
        //else if(hit.collider.gameObject.name != "Heal")
        //{
        //    heal = false;
        //}


    }


    public void Launch()
    {
        Destroy(e.gameObject);
        heal = false;
    }
}

