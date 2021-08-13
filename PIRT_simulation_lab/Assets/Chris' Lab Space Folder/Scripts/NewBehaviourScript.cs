using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float radius;
    public float elevation;
    public float polar;
    private float anglePolarTotal;
    private float angleElevationTotal;
    public float polarAvg;
    public float elevationAvg;
    public float electricCharge;
    public float kConstant;
    public float xValueSum, yValueSum, zValueSum = 0;
    public float xValueAvg, yValueAvg, zValueAvg;

    public float dummyVariable1;
    public float dummyVariable2;

    //Values
    public Vector3 Carrier = new Vector3();
    public Vector3 eFieldAvg = new Vector3();
    public float xValueCarrier;
    public float yValueCarrier;
    public float zValueCarrier;

    // Lists
    public List<GameObject> SpheresList = new List<GameObject>();
    

    public List<Vector3> SpheresPositionList = new List<Vector3>();
    public List<Vector3> PastSpheresPositionList = new List<Vector3>();
    public List<Vector3> CurrentSpheresPositionList = new List<Vector3>();

    public List<float> ChargeList = new List<float>();
    public List<float> xValueList = new List<float>();
    public List<float> yValueList = new List<float>();
    public List<float> zValueList = new List<float>();
    public List<float> elevationList = new List<float>();
    public List<float> polarAngleList = new List<float>();
    public List<float> radiusList = new List<float>();
    public List<float> electricFieldList = new List<float>();


    public List<int> electricCharges = new List<int>();


    public Vector3 ObjectPosition;

    public GameObject childArrowObject;


    // Start is called before the first frame update
    void Start()
    {
        electricCharges.Add(-1);
        electricCharges.Add(1);
        electricCharges.Add(2);

        StartupPrep();
        kConstant = 8.99f * (Mathf.Pow(10,9));
        electricCharge = 1.602f * Mathf.Pow(10f, -19);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SpherePositionUpdate();
        
    }

    //Set-Up on Start
    public void StartupPrep()
    {
        foreach (GameObject fooObject in GameObject.FindGameObjectsWithTag("Charge"))
        {
            SpheresList.Add(fooObject);
        }
        ObjectPosition = this.gameObject.transform.localPosition;
        CallSpherePosition();
        PastSpheresPositionList = new List<Vector3>(SpheresPositionList);
        CurrentSpheresPositionList = new List<Vector3>(SpheresPositionList);
        SimUpdate();
        //Debug.Log("Startup Prep run");
    }

    //Update Method - Updating position of spheres
    public void SpherePositionUpdate()
    {
        for(int i = 0; i < SpheresPositionList.Count; i++)
        {
            if (CurrentSpheresPositionList[i] != PastSpheresPositionList[i])
            {
                SimUpdate();
            }
        }

        CurrentSpheresPositionList.Clear();
        SpheresPositionList.Clear();
        CallSpherePosition();
        CurrentSpheresPositionList = new List<Vector3>(SpheresPositionList);
        
    }

    public void SimUpdate()
    {
        //Math Moment
        FullCalculationReset();
        AxialDistances();
        ConversionToList();
        ElectricFieldCalculations();
        //FindDirection();

        //Reset Past Sphere Position List
        //FullCalculationReset();
        PastSpheresPositionList = new List<Vector3>(SpheresPositionList);
        //Debug.Log("Position change");
    }

    //Finding position of all spheres
    public void CallSpherePosition()
    {
        for (int currentSphere = 0; currentSphere < SpheresList.Count; currentSphere++ )
        {
            Carrier = SpheresList[currentSphere].transform.localPosition - ObjectPosition;
            SpheresPositionList.Add(Carrier);
        } 
    }

    //Finding Axis positions for all spheres
    public void AxialDistances()
    {
        for (int currentSphere = 0; currentSphere < SpheresList.Count; currentSphere++)
        {
            Carrier = SpheresPositionList[currentSphere];
            xValueList.Add(Carrier.x);
            yValueList.Add(Carrier.y);
            zValueList.Add(Carrier.z);
        }
    }

    //Converting sphere positions to polar coordinates
    public void ConversionToList()
    {
        for (int currentSphere = 0; currentSphere < SpheresList.Count; currentSphere++)
        {
            Carrier = SpheresPositionList[currentSphere];
            CartesianToSpherical(Carrier, out radius, out polar, out elevation);
            radToDeg(polar, elevation, out polar, out elevation);
            if (polar < 0)
            {
                polar += 360;
            }
            elevationList.Add(elevation);
            polarAngleList.Add(polar);
            radiusList.Add(radius);
        }
    }

    public void FindDirection()
    {
        //Finding sum of polar angle
        for (int currentSphere = 0; currentSphere < SpheresList.Count; currentSphere++)
        {
            anglePolarTotal += polarAngleList[currentSphere];
        }

        //Finding sum of elevation angle
        for (int currentSphere = 0; currentSphere < SpheresList.Count; currentSphere++)
        {
            angleElevationTotal += elevationList[currentSphere];
        }

        //averaging the polar and elevation sum totals
        polarAvg = anglePolarTotal / SpheresList.Count;
        elevationAvg = angleElevationTotal / SpheresList.Count;

        //applying the average direction of the polar and elevation angles to the game object
        this.gameObject.transform.rotation = Quaternion.Euler(0, -polarAvg, -90);
        childArrowObject.gameObject.transform.localRotation = Quaternion.Euler(0, 0, elevationAvg);
    }

    public void FullCalculationReset()
    {
        PastSpheresPositionList.Clear();
        xValueList.Clear();
        yValueList.Clear();
        zValueList.Clear();
        elevationList.Clear();
        polarAngleList.Clear();
        radiusList.Clear();
        anglePolarTotal = 0;
        angleElevationTotal = 0;
        polarAvg = 0;
        elevationAvg = 0;
        xValueAvg = 0;
        yValueAvg = 0;
        zValueAvg = 0;
        xValueSum = 0;
        yValueSum = 0;
        zValueSum = 0;
        
    }

    // Electric Field Calculations
    public void ElectricFieldCalculations()
    {
        
        for (int currentSphere = 0; currentSphere < SpheresList.Count; currentSphere++)
        {
            //dummyVariable1 = kConstant * electricCharge;
            
            xValueSum += -electricCharges[currentSphere]*(xValueList[currentSphere] / Mathf.Pow(radiusList[currentSphere],3));
            //xValueSum = 10;
            yValueSum += -electricCharges[currentSphere] * (yValueList[currentSphere] / Mathf.Pow(radiusList[currentSphere], 3));
            zValueSum += -electricCharges[currentSphere] * (zValueList[currentSphere] / Mathf.Pow(radiusList[currentSphere], 3));
        }

        xValueAvg = xValueSum / SpheresList.Count;
        yValueAvg = yValueSum / SpheresList.Count;
        zValueAvg = zValueSum / SpheresList.Count;

        eFieldAvg = new Vector3(xValueSum, yValueSum, zValueSum);

        //Debug.Log(eFieldAvg);

        CartesianToSpherical(eFieldAvg, out elevation, out polar, out elevation);

        //Debug.Log(polar);
        //Debug.Log(elevation + " elevation");

        radToDeg(polar, elevation, out polar, out elevation);

        this.gameObject.transform.rotation = Quaternion.Euler(0, -polar, -90);
        childArrowObject.gameObject.transform.localRotation = Quaternion.Euler(0, 0, elevation);

    }



    //Spherical Coordinate shenanigans
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

    public void radToDeg(float inRadians, float inElevation, out float polar, out float elevation)
    {
        polar = inRadians * 180 / Mathf.PI;
        elevation = inElevation * 180 / Mathf.PI;
    }
}
