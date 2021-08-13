using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class LerpSphereDemo : MonoBehaviour
{
    
    public Transform start;
    public Transform end1;
    public Transform end2;

    [Range(0f, 1f)]
    public float LerpPercentage;
    public bool lerpUp = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lerpUp)
        {
            LerpPercentage += 0.01f;
        }

        if(LerpPercentage >= 1f && lerpUp == true)
        {
            lerpUp = false;
        }

        if (!lerpUp)
        {
            LerpPercentage -= 0.01f;
        }

        if (LerpPercentage <= 0f)
        {
            LerpPercentage += 0.01f;
            lerpUp = true;
        }
        
        this.transform.position = Vector3.Lerp(start.position, end1.position, LerpPercentage);
        this.transform.rotation = Quaternion.Lerp(start.rotation, end1.rotation, LerpPercentage);


    }
}
