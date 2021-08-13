using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    private Renderer sphereRenderer;
    public Color myColor;

    // Start is called before the first frame update
    void Start()
    {
        sphereRenderer = this.gameObject.GetComponent<MeshRenderer>();
        sphereRenderer.material.color = myColor;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
