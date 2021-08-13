using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSim : MonoBehaviour
{

    //Useful Constants
    float pi = 3.14159f;

    public float initialVelocity;

    public float initialVelocity_Y;
    public float initialVelocity_X;

    public float currentVelocity_X;
    public float currentVelocity_Y;

    public float gravity;
    public float time;
    public float cannonAngle = 0;

    public bool Run = false;

    public Rigidbody rb;

    public GameObject trail;
    public GameObject cannon;



    // Start is called before the first frame update
    void Start()
    {
        gravity = 9.81f;
        initialVelocity = 10;
        //initialVelocity_X = 10;
        //initialVelocity_Y = 20;
        //rb.velocity = new Vector3(initialVelocity_X, initialVelocity_Y, 0);
        //Destroy(this.gameObject, 10);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        Run = false;
        time = 0;
        this.gameObject.transform.position = new Vector3(6, 2, 10);
        // Vertical direction
        currentVelocity_Y = 0;
        //Horizontal direction with no friction or air resistance
        currentVelocity_X = 0;
        rb.velocity = new Vector3(currentVelocity_X, currentVelocity_Y, 0);
    }

    public float RadianToDegree(float radian)
    {
        float result = radian * (180f / pi);
        return result;
    }

    public void NewAngle(float newAngle)
    {
        cannonAngle = newAngle;

    }

    public void NewVelocity(float newVelocity)
    {
        initialVelocity = newVelocity;

    }

    public void StartPressed()
    {
        Run = true;
    }

    private void FixedUpdate()
    {
        if (Run == false)
        {
            initialVelocity_Y = initialVelocity * (Mathf.Sin(cannonAngle*pi/180));
            initialVelocity_X = initialVelocity * (Mathf.Cos(cannonAngle*pi/180));
        }
        

        if (Run == true)
        {
            if (transform.position.y <= 0.5)
            {
                currentVelocity_Y = 0;
            }
            else
            {
                time = time + Time.fixedDeltaTime;
                // Vertical direction
                currentVelocity_Y = initialVelocity_Y - gravity * time;
                //Horizontal direction with no friction or air resistance
                currentVelocity_X = initialVelocity_X;
                rb.velocity = new Vector3(currentVelocity_X, currentVelocity_Y, 0);
            }
            if (transform.position.y > 0.5)
            {
                Instantiate(trail, transform.position, transform.rotation);
            }
            
        }
    }
}
