using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Vector3 gravity;
    public Rigidbody rb;
    public Vector3 velocity;
    public float timeStep = 0.02f;
    public float gravityValue = -9.8f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gravity = new Vector3(0, gravityValue, 0);
    }


    void FixedUpdate()
    {

        velocity = this.gameObject.GetComponent<Rigidbody>().velocity;
        rb.AddForce(gravity, ForceMode.Acceleration);


        /*startPosition = this.transform.position;

        this.transform.position += (velocity * time + 0.5 * gravity * time * time);

        endPosition = this.transform.position;

        velocity = (endPosition - startPosition)/time;

        rb.AddForce(new Vector3(0,gravity,0), ForceMode.Acceleration);
        */
    }
}
