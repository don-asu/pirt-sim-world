using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    //Game Objects and UI
    public Text Menu;
    public GameObject SceneMenu;
    public GameObject KinematicInterface;
    public GameObject ArrayInterface;
    public GameObject EnMInterface;

    //Scenes
    public int CurrentScene;
    public int LeftScene;
    public int RightScene;

    // Kinematics = 10 : Camera (30,2,-20)
    // E-Field = 9     : Camera (-25,2,-10)

    public void Start()
    {

        CurrentScene = 9;

        if (CurrentScene == 8)
        {
            //Array Practice
            ArrayInterface.SetActive(true);
            GameObject.Find("Main Camera").transform.position = new Vector3(-40, 2, -20);
            Menu.text = "Array Practice";

        }
        else if (CurrentScene == 9)
        {
            //E&M
            KinematicInterface.SetActive(false);
            ArrayInterface.SetActive(false);
            EnMInterface.SetActive(true);
            GameObject.Find("Main Camera").transform.position = new Vector3(-25, 2, -10);
            Menu.text = "E & M";
        }
        else if (CurrentScene == 10)
        {
            //Kinematics

            KinematicInterface.SetActive(true);
            GameObject.Find("Main Camera").transform.position = new Vector3(30, 2, -20);
            Menu.text = "Kinematics Sim";
        }
    }

    public void Update()
    {
        LeftScene = CurrentScene - 1;
        RightScene = CurrentScene + 1;

        LeftScroll();
    }

    //Menu Button
    public bool Pressed = false;

    //Menu Button
    public void ButtonClick()
    {
        if (Pressed == false)
        {
            SceneMenu.SetActive(true);
            Pressed = true;
        }
        else
        {
            SceneMenu.SetActive(false);
            Pressed = false;
        }
    }

    //Decrease current scene value by 1
    public void LeftScroll()
    {
        if (CurrentScene == 8)
        {
            //Array Practice
            ArrayInterface.SetActive(true);
            KinematicInterface.SetActive(false);
            EnMInterface.SetActive(false);
            GameObject.Find("Main Camera").transform.position = new Vector3(-40, 2, -15);
            Menu.text = "Array Practice";
        }
        else if (CurrentScene == 9)
        {
            //E&M
            KinematicInterface.SetActive(false);
            ArrayInterface.SetActive(false);
            EnMInterface.SetActive(true);
            GameObject.Find("Main Camera").transform.position = new Vector3(-25, 2, -10);
            Menu.text = "E & M";
        }
        else if (CurrentScene == 10)
        {
            //Kinematics
            ArrayInterface.SetActive(false);
            KinematicInterface.SetActive(true);
            EnMInterface.SetActive(false);
            GameObject.Find("Main Camera").transform.position = new Vector3(30, 2, -20);
            Menu.text = "Kinematics Sim";
        }
    }
    public void LeftButton()
    {

        CurrentScene -= 1;
    }

    public void RightButton()
    {
        CurrentScene += 1;
    }

   
}
