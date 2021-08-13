using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchOnClick : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnTransform;
    public float projForce = 1000f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Mouse button clicked.");
            Instantiate(projectile, spawnTransform.position, spawnTransform.rotation);
        }
    }
}
