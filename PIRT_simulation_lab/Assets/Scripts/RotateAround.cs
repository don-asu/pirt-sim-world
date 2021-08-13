using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public GameObject target;
    [Range(0f,100f)]
    public float rotSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, rotSpeed * Time.deltaTime);
    }
}
