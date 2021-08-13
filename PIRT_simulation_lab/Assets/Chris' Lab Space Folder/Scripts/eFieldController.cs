using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eFieldController : MonoBehaviour
{
    public GameObject Vector;
    public Vector3 position = new Vector3(-80, 1, -10);
    public int stepSize = 1;

    public VectorController launch;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiation in the X-Direction
        for (int xCount = 0; xCount <= 25; xCount++)
        {
            position.y = 1;
            //Instantiation in the y direction
            for (int yCount = 0; yCount <= 5; yCount++)
            {
                position.z = -10;
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
