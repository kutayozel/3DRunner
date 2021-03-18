using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
   
	public Rigidbody rb;
    public float speed;
    //public float angularSpeed;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    {
        rb.angularVelocity = new Vector3(0,0,speed * Time.deltaTime);
        //rb.AddTorque(0f,0f,speed * Time.deltaTime);
        //rb.velocity = new Vector3(0f,0f,speed * Time.deltaTime);
    }

}
