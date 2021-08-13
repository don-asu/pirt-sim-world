using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour
{
    [Range(-1f,1f)]
    public float f = 0;
    public Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        startPos = startPos + new Vector3(Mathf.Sin(Time.time) * Time.deltaTime, 0f, 0f);
    }
}
