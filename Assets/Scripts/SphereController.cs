using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    Rigidbody move;
    private CharacterController control;
    bool gamestart = true;
    bool sphereonplane = true;

    void Start()
    {
        move = GetComponent<Rigidbody>();
        control = GetComponent<CharacterController>();
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if (gamestart)
        {
            //move.AddForce(new Vector3(0, 0, 1));
            transform.Translate(Vector3.forward * Time.deltaTime * 3f);

        }

        if (Input.GetButtonDown("Fire1") && sphereonplane)
        {
            move.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            sphereonplane = false;
        }


        
     









}
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            sphereonplane = true;
        }
    }
}
