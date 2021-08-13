using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmCharges : MonoBehaviour
{
    // Lists
    public List<GameObject> chargeList = new List<GameObject>();

    // Game Objects
    public GameObject chargeObject;
    private GameObject chargeSelected;

    // Constants

    // Variables
    public int selectedCharge;
    public int previousCharge;
    public int followingCharge;

    // Colors
    public Color selected;
    public Color negativeCharge;
    public Color positiveCharge;

    // Vector3's & Positions
    public Vector3 simCenter;
    public Vector3 chargeIntantiatePosition;
    public Vector3 chargeOffset;

    public int xPosition;
    public int yPosition;
    public int zPosition;

    // Booleans

    //Renderer
    private Renderer chargeRenderer;

    //UI Assets
    public Text xPosSymbol;
    public Text xNegSymbol;
    public Text yPosSymbol;
    public Text yNegSymbol;
    public Text zPosSymbol;
    public Text zNegSymbol;

    public Text currentCharge;
    public Text xPositionText;
    public Text yPositionText;
    public Text zPositionText;


    // Start is called before the first frame update
    void Start()
    {
        //xPosSymbol.text = "2";
        simCenter = this.transform.position;
        chargeIntantiatePosition = simCenter;
    }

    // Update is called once per frame
    void Update()
    {
        changeColor();
        updateUI();
    }



    //Instantiating a charge (UI button)
    public void createCharge()
    {
        chargeList.Add(Instantiate(chargeObject, chargeIntantiatePosition, transform.rotation) as GameObject);
        selectedCharge = chargeList.Count - 1;
    }

    //Selecting the following charge in the list
    public void selectNextCharge()
    {
        selectedCharge += 1;
        updateUI();
    }

    //Selecting the previous charge in the list
    public void selectPreviousCharge()
    {
        selectedCharge -= 1;
        updateUI();
    }

    //Changes color depending on selected object
    public void changeColor()
    {
        previousCharge = selectedCharge - 1;
        followingCharge = selectedCharge + 1;

        if (chargeList.Count >= 1)
        {
            chargeSelected = chargeList[selectedCharge];
            chargeRenderer = chargeSelected.GetComponent<MeshRenderer>();
            chargeRenderer.material.color = selected;
        }

        if (selectedCharge > 1)
        {
            chargeSelected = chargeList[previousCharge];
            chargeRenderer = chargeSelected.GetComponent<MeshRenderer>();
            chargeRenderer.material.color = negativeCharge;
        }
        
        if (selectedCharge < chargeList.Count || selectedCharge > 1)
        {
            chargeSelected = chargeList[followingCharge];
            chargeRenderer = chargeSelected.GetComponent<MeshRenderer>();
            chargeRenderer.material.color = negativeCharge;
        }
    }

    //Moving the charge in 3d space with buttons
    public void movePosX()
    {
        chargeSelected = chargeList[selectedCharge];
        xPosition = (int)chargeSelected.transform.position.x + 1;
        yPosition = (int)chargeSelected.transform.position.y;
        zPosition = (int)chargeSelected.transform.position.z;
        chargeSelected.transform.position = new Vector3(xPosition, yPosition, zPosition);
        updateUI();
    }

    public void moveNegX()
    {
        chargeSelected = chargeList[selectedCharge];
        xPosition = (int)chargeSelected.transform.position.x - 1;
        yPosition = (int)chargeSelected.transform.position.y;
        zPosition = (int)chargeSelected.transform.position.z;
        chargeSelected.transform.position = new Vector3(xPosition, yPosition, zPosition);
        updateUI();
    }

    public void movePosY()
    {
        chargeSelected = chargeList[selectedCharge];
        xPosition = (int)chargeSelected.transform.position.x;
        yPosition = (int)chargeSelected.transform.position.y + 1;
        zPosition = (int)chargeSelected.transform.position.z;
        chargeSelected.transform.position = new Vector3(xPosition, yPosition, zPosition);
        updateUI();
    }

    public void moveNegY()
    {
        chargeSelected = chargeList[selectedCharge];
        xPosition = (int)chargeSelected.transform.position.x;
        yPosition = (int)chargeSelected.transform.position.y - 1;
        zPosition = (int)chargeSelected.transform.position.z;
        chargeSelected.transform.position = new Vector3(xPosition, yPosition, zPosition);
        updateUI();
    }

    public void movePosZ()
    {
        chargeSelected = chargeList[selectedCharge];
        xPosition = (int)chargeSelected.transform.position.x;
        yPosition = (int)chargeSelected.transform.position.y;
        zPosition = (int)chargeSelected.transform.position.z + 1;
        chargeSelected.transform.position = new Vector3(xPosition, yPosition, zPosition);
        updateUI();
    }

    public void moveNegZ()
    {
        chargeSelected = chargeList[selectedCharge];
        xPosition = (int)chargeSelected.transform.position.x;
        yPosition = (int)chargeSelected.transform.position.y;
        zPosition = (int)chargeSelected.transform.position.z - 1;
        chargeSelected.transform.position = new Vector3(xPosition, yPosition, zPosition);
    }

    //UI Methods : changing position text, pos/neg symbols

    public void updateUI()
    {
        int xText = xPosition + 25;
        currentCharge.text = selectedCharge.ToString();
        xPositionText.text = xText.ToString();
        yPositionText.text = yPosition.ToString();
        zPositionText.text = zPosition.ToString();

        //X Position
        if(xPosition == 0)
        {
            xPosSymbol.enabled = false;
            xNegSymbol.enabled = false;
        }
        else if(xPosition > 0)
        {
            xPosSymbol.enabled = true;
            xNegSymbol.enabled = false;

        }
        else if (xPosition < 0)
        {
            xPosSymbol.enabled = false;
            xNegSymbol.enabled = true;
        }

        //Y Position
        if (yPosition == 0)
        {
            yPosSymbol.enabled = false;
            yNegSymbol.enabled = false;
        }
        else if (yPosition > 0)
        {
            yPosSymbol.enabled = true;
            yNegSymbol.enabled = false;

        }
        else if (yPosition < 0)
        {
            yPosSymbol.enabled = false;
            yNegSymbol.enabled = true;
        }

        //Z Position
        if (zPosition == 0)
        {
            zPosSymbol.enabled = false;
            zNegSymbol.enabled = false;
        }
        else if (zPosition > 0)
        {
            zPosSymbol.enabled = true;
            zNegSymbol.enabled = false;

        }
        else if (zPosition < 0)
        {
            zPosSymbol.enabled = false;
            zNegSymbol.enabled = true;
        }
    }

}
