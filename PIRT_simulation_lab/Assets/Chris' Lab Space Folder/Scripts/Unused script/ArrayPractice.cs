using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayPractice : MonoBehaviour
{
    //Arrays and Game Objects
    public GameObject Sphere;
    public List<GameObject> SphereClones = new List<GameObject>();
    private GameObject SelectedSphereObject;

    //Color
    public Color DeselectedColor;
    public Color SelectedColor;

    //Positions
    Vector3 Center;
    Vector3 StartOffset;
    Vector3 Position;

    float Position_x;
    float Position_y;

    // Values
    public int SelectedSphere;

    //Booleans
    public bool isStarted;
    public bool firstBallSpawned = false;

    //Renderer
    private Renderer sphereRenderer;

    //------------

    void Start()
    {
        Center = new Vector3(-40, 2, 10);
        StartOffset = new Vector3(-5, 0, 0);
        Position = Center + StartOffset;
        Position_x = Position.x;
        Position_y = Mathf.Sin(Position_x) + 2;

        SelectedSphere = 0;
        Position = new Vector3(Position_x, Position_y, Position.z);
    }

    void Update()
    {
        //CurrentSphere();
    }

    //-----------

    // Creating Sphere
    public void InstantiateSphere()
    {
        SphereClones.Add(Instantiate(Sphere, Position, transform.rotation) as GameObject);
        Position_x += 0.5f;
        Position_y = Mathf.Sin(Position_x)+2;
        Position = new Vector3(Position_x, Position_y, Position.z);
    }

    public void NextSphere()
    {
        SelectedSphereObject = SphereClones[SelectedSphere];
        sphereRenderer = SelectedSphereObject.GetComponent<MeshRenderer>();
        sphereRenderer.material.color = SelectedColor;

        if (SelectedSphere >= 1)
        {
            DeselectSphereLeft();
        }

        SelectedSphere += 1;
    }

    public void PreviousSphere()
    {
        SelectedSphere -= 1;
        SelectedSphereObject = SphereClones[SelectedSphere-1];
        sphereRenderer = SelectedSphereObject.GetComponent<MeshRenderer>();
        sphereRenderer.material.color = SelectedColor;
        

        DeselectSphereRight();
        
    }

    public void DeselectSphereLeft()
    {
        SelectedSphereObject = SphereClones[SelectedSphere - 1];
        sphereRenderer = SelectedSphereObject.GetComponent<MeshRenderer>();
        sphereRenderer.material.color = DeselectedColor;
    }

    public void DeselectSphereRight()
    {
        SelectedSphereObject = SphereClones[SelectedSphere];
        sphereRenderer = SelectedSphereObject.GetComponent<MeshRenderer>();
        sphereRenderer.material.color = DeselectedColor;
    }

    public void ChangeSphereCharge()
    {

    }

    public void DeleteSphere()
    {
        //Destroy(SelectedSphereObject);
    }
}
