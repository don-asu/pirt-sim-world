using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector : MonoBehaviour
{
    // Useful Values
    public float pi;
    public float k;
    public float ElectricCharge;

    // Changing Values
    public float E_Field;

    public float E_Field_x;
    public float E_Field_y;
    public float E_Field_z;

    public float Distance_x;
    public float Distance_y;
    public float Distance_z;

    public float r_distance;

    // Viewing
    public Vector3 ChargeDirection;

    // Directional Values
    public float Direction_x;
    public float Direction_y;
    public float Direction_z;

    public Vector3 RotationalValues;

    // Position Values
    public float Parent_x;
    public float Parent_y;
    public float Parent_z;

    public float Vector_x;
    public float Vector_y;
    public float Vector_z;

    public float Charge_x;
    public float Charge_y;
    public float Charge_z;

    // Game Objects
    public GameObject Charge;
    public GameObject Parent;

    // Lists
    public List<GameObject> SpheresList = new List<GameObject>();
    public List<float> ChargeList = new List<float>();


    // Start is called before the first frame update
    void Start()
    {
        pi = 3.14f;
        k = 8987550000f;
        ElectricCharge = 0.000000001f;
        foreach (GameObject fooObject in GameObject.FindGameObjectsWithTag("Charge"))
        {
            SpheresList.Add(fooObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ParentPosition();
        VectorPosition();
        ChargePosition();
        DirectionalDistance();
        ObjectDistance();
        ElectricField();
        DirectionalElectricField();
        AngleVector();
        //transform.LookAt(Charge.transform);
    }

    public void ParentPosition()
    {
        Parent_x = Parent.gameObject.transform.position.x;
        Parent_y = Parent.gameObject.transform.position.y;
        Parent_z = Parent.gameObject.transform.position.z;
    }

    public void VectorPosition()
    {
        Vector_x = this.gameObject.transform.position.x - Parent_x;
        Vector_y = this.gameObject.transform.position.y - Parent_y;
        Vector_z = this.gameObject.transform.position.z - Parent_z;
    }

    public void ChargePosition()
    {
        Charge_x = Charge.transform.position.x - Parent_x;
        Charge_y = Charge.transform.position.y - Parent_y;
        Charge_z = Charge.transform.position.z - Parent_z;
    }

    public void DirectionalDistance()
    {
        Distance_x = Vector_x - Charge_x;
        Distance_y = Vector_y - Charge_y;
        Distance_z = Vector_z - Charge_z;
    }

    public void ObjectDistance()
    {
        r_distance = Mathf.Sqrt((Distance_x * Distance_x) + (Distance_y * Distance_y) + (Distance_z * Distance_z));
    }

    public void ElectricField()
    {
        // E = kQ / r^2

        E_Field = k * ElectricCharge / (r_distance * r_distance);
    }

    public void DirectionalElectricField()
    {
        E_Field_x = k * ElectricCharge / (Distance_x * Distance_x);
        E_Field_y = k * ElectricCharge / (Distance_y * Distance_y);
        E_Field_z = k * ElectricCharge / (Distance_z * Distance_z);
    }

    public void AngleVector()
    {
        //do math here
    }

    public float RadToDeg(float radian)
    {
        float result = radian * (180f * pi);
        return result;
    }





    //Spherical coordinate shenanigans

    public void DetermineRadius()
    {

    }

    public void DetermineElevation()
    {

    }

    public void DeterminePolar()
    {

    }

    public static void SphericalToCartesian(float radius, float polar, float elevation, out Vector3 outCart)
    {
        float a = radius * Mathf.Cos(elevation);
        outCart.x = a * Mathf.Cos(polar);
        outCart.y = radius * Mathf.Sin(elevation);
        outCart.z = a * Mathf.Sin(polar);
    }

    public static void CartesianToSpherical(Vector3 cartCoords, out float outRadius, out float outPolar, out float outElevation)
    {
        if (cartCoords.x == 0)
            cartCoords.x = Mathf.Epsilon;
        outRadius = Mathf.Sqrt((cartCoords.x * cartCoords.x)
                        + (cartCoords.y * cartCoords.y)
                        + (cartCoords.z * cartCoords.z));
        outPolar = Mathf.Atan(cartCoords.z / cartCoords.x);
        if (cartCoords.x < 0)
            outPolar += Mathf.PI;
        outElevation = Mathf.Asin(cartCoords.y / outRadius);
    }

}
