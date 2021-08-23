using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eFieldController : MonoBehaviour
{
    public GameObject Vector;
    public Transform origin;
    public Vector3 position;
    public float stepSize = 0.3f;

    public VectorController launch;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3 (origin.position.x, origin.position.y, origin.position.z);
        //Instantiation in the X-Direction
        for (int xCount = 0; xCount <= 30; xCount++)
        {
            position.y = origin.position.y;
            //Instantiation in the y direction
            for (int yCount = 0; yCount <= 8; yCount++)
            {
                position.z = origin.position.z;
                //Instantiation in the z direction
                for (int zCount = 0; zCount <= 10; zCount++)
                {
                    Instantiate(Vector, position, transform.rotation);
                    position.z+= stepSize;
                }
                position.y+= stepSize;
            }
            position.x+= stepSize;
        }

        launch.startingController();

    }
}
