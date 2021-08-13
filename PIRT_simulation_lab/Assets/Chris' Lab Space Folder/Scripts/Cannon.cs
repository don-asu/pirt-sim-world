using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{

    public GameObject cannon;
    public float Angle = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cannon.transform.eulerAngles = new Vector3(0, 0, Angle - 90);
    }

    public void NewAngle(float newAngle)
    {
        Angle = newAngle;
        
    }
}
