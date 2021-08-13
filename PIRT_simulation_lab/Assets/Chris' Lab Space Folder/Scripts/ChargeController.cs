using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeController : MonoBehaviour
{
    //Two mandatory lists
    public List<GameObject> ChargeList = new List<GameObject>();
    public List<int> ChargeValueList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {

        //Detecting amount of spheres at start and applying to amount of charges
        foreach (GameObject fooObject in GameObject.FindGameObjectsWithTag("Charge"))
        {
            ChargeList.Add(fooObject);
        }

        for (int count = 0; count < ChargeList.Count; count++)
        {
            ChargeValueList.Add(1);
        }
    }

    //Returning the charge value to vector controller script
    public void RetrieveChargeValue(int currentCharge, out int chargeValue)
    {
        chargeValue = ChargeValueList[currentCharge];
    }

}
