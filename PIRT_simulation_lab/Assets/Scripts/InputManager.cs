using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private void Start()
    {
        //Debug.Log(Screen.width);
        //Debug.Log(Screen.height);
    }
    void Update()
    {
        if(Input.GetMouseButtonUp (0))
        {
            Debug.Log(Input.mousePosition);
        }
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button is pressed");
        }
        else if (Input.GetMouseButton(0))
        {
            Debug.Log("Left mouse button is held down.");
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Left mouse button is released");
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("right mouse button is pressed");
        }
        else if (Input.GetMouseButton(1))
        {
            Debug.Log("right mouse button is held down.");
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Debug.Log("right mouse button is released");
        }*/
    }
}
