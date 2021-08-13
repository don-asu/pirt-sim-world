using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorController : MonoBehaviour
{
    //Lists of game objects
    public List<GameObject> vectorList = new List<GameObject>();
    public List<GameObject> chargeList = new List<GameObject>();
    public List<GameObject> bodyList   = new List<GameObject>();

    //E-Field calculation values
    public float Ex = 0;
    public float Ey = 0;
    public float Ez = 0;
    public float k = 1;
    public float q = 1;
    public float Q = 1;

    //Spherical cordinate values
    public float radius = 0;
    public float elevation = 0;
    public float polar = 0;

    //Secondary gameobject value
    public GameObject childArrowObject;

    //Referencing the charge controller script
    public ChargeController getCharge;

    //Dummy trigger boolean value
    public bool trigger = true;
    public bool startup = false;
    public bool update = false;

    //Defining the required base lists of each game object 
    void Start()
    {
        
    }

    //Update function
    void Update()
    {
        if (startup)
        {
            startUp();
            startup = false;
        }
        if (update)
        {
            ElectricFieldCalculations();
        }
    }

    //Start
    public void startUp()
    {
        foreach (GameObject fooObject in GameObject.FindGameObjectsWithTag("Vector"))
        {
            vectorList.Add(fooObject);
        }

        foreach (GameObject fooObject in GameObject.FindGameObjectsWithTag("Charge"))
        {
            chargeList.Add(fooObject);
        }
        foreach (GameObject fooObject in GameObject.FindGameObjectsWithTag("VectorBody"))
        {
            bodyList.Add(fooObject);
        }
    }

    public void startingController()
    {
        startup = true;
        update = true;

    }

    //Method for calculating te electric field and changing the direction of the arrows
    public void ElectricFieldCalculations()
    {
        //first for loop to run over each vector
        for(int count = 0; count < vectorList.Count; count++)
        {
            //Redefining the variables for each vector for each loop
            Ex = 0;
            Ey = 0;
            Ez = 0;
            childArrowObject = bodyList[count];

            //Second for loop to run over each charge
            for (int counter = 0; counter < chargeList.Count; counter++)
            {
                //Obtaining directional distance and their magnitudes
                float distanceMagnitude = Vector3.Distance(chargeList[counter].transform.position, vectorList[count].transform.position);
                float distanceX = chargeList[counter].transform.position.x - vectorList[count].transform.position.x;
                float distanceY = chargeList[counter].transform.position.y - vectorList[count].transform.position.y;
                float distanceZ = chargeList[counter].transform.position.z - vectorList[count].transform.position.z;

                //Obtaining Charge Value for q
                getCharge.RetrieveChargeValue(counter, out int q);

                //Direcitonal E-Field calculations
                Ex += -k * q * distanceX / Mathf.Pow(distanceMagnitude, 3);
                Ey += -k * q * distanceY / Mathf.Pow(distanceMagnitude, 3);
                Ez += -k * q * distanceZ / Mathf.Pow(distanceMagnitude, 3);
                Vector3 eField = new Vector3(Ex, Ey, Ez);

                //Conversions to usable values for rotation
                CartesianToSpherical(eField, out elevation, out polar, out elevation);
                RadToDeg(polar, elevation, out polar, out elevation);

                //Application of rotational values to the vector gameobject
                vectorList[count].gameObject.transform.rotation = Quaternion.Euler(0, -polar, -90);
                childArrowObject.gameObject.transform.localRotation = Quaternion.Euler(0, 0, elevation);
            }
        }
    }

    //Conversion of coordinate systems
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

    //Conversion from radians to degrees
    public void RadToDeg(float inRadians, float inElevation, out float polar, out float elevation)
    {
        polar = inRadians * 180 / Mathf.PI;
        elevation = inElevation * 180 / Mathf.PI;
    }
}
