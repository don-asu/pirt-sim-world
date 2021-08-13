using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 500f;

    void Awake()
    {
        rb.AddForce(Vector3.forward * force);
    }

  /* Rigidbody rb;

    public float forceY;
    public bool isGrounded;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        isGrounded = false;
        forceY = 0f;
    }


    void Update()
    {
        if (Input.GetMouseButton(0) && isGrounded)
        {
            Debug.Log("Mouse button is held down.");
            forceY = forceY + 100f * Time.deltaTime;
        }
        else if(Input.GetMouseButtonUp(0) && isGrounded)
        {
            rb.AddForce(new Vector3(0f, forceY, 300f));
            forceY = 0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isGrounded = false;
        }
    }*/

}
