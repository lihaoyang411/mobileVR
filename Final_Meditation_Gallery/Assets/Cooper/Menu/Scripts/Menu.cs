using System;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static bool CTRL;
    public static bool R;
    public static bool L;
    public static bool U;
    public static bool D;
    public static String T;

    public GameObject DialMenu;
    public bool MainDial { get; set; } // True == Main || False == Backpack
    public bool OpenMenu { get; set; }
    public int BoxType { get; set; }
    public string Response { get; set; }

    public GameObject Center;
    public GameObject LC;
    public GameObject BackSplash;
    public GameObject SettingsMenu;
    public GameObject MusicMenu;
    public GameObject TimerMenu;
    public GameObject Exit;

    public GameObject[] Top = new GameObject[3];
    public GameObject[] Left = new GameObject[3];
    public GameObject[] Right = new GameObject[3];
    public GameObject[] Bottom = new GameObject[2];
    // For the 4 Arrays above:
    // Position 0 is for which panel you are on
    // Position 1 is for the Main Dial
    // Position 2 is for the Backpack Dial 

    private void Start()
    {
        LC.SetActive(true);
        DialMenu.SetActive(false);
        Exit.SetActive(false);
        Backpack();
        Response = "";
        R = false;
        L = false;
        U = false;
        D = false;
        BoxType = -1;
        T = "";
    }

    private void Backpack() // Opens BackPack
    {
        if (MainDial) // If it is closed, then open it
        {
            // Set MainDial Variable to False ("Second Dial")
            MainDial = false;
            // Set all Variables of Dial 1 to false
            SetAllArrays(1, false);
            // Set all Variables of Dial 2 to false
            SetAllArrays(2, true);
        }
        else // Else, close the backpack
        {
            // Set MainDial Variable to False ("First Dial")
            MainDial = true;
            // Set all Variables of Dial 2 to false
            SetAllArrays(2, false);
            // Set all Variables of Dial 1 to true
            SetAllArrays(1, true);
        }
    }

    private void SetAllArrays(int i, bool b) // Condensed Repeated Commands to switch dials
    {
        Top[i].SetActive(b);
        Left[i].SetActive(b);
        Right[i].SetActive(b);
    }

    private void OpenAMenu() // Open up a new Menu **Menu Switcher**
    {
        if (BoxType == 1) // Open Exit Message Box
        {
            if (!Exit.activeSelf) Exit.SetActive(true);

            if (R) // Response is "F"
            {
                BoxType = 0;
                Exit.SetActive(false);
            }
            else if (L) // Response is "T"
            {
                if (T == "Home") LC.gameObject.GetComponent<LevelChanger>().FadeToLevel(1);
                else if (T == "Game") LC.gameObject.GetComponent<LevelChanger>().FadeToLevel(0);
                BoxType = 0;
                DialMenu.SetActive(false);
            }
        }
        else if (BoxType == 2) // Open Menu
        {
            if(!BackSplash.activeSelf) BackSplash.SetActive(true);

            if (D)
            {
                BoxType = 0;
            }
            else if (T == "Music")
            {
                if (!MusicMenu.activeSelf) MusicMenu.SetActive(true);

                // Music Code
                

            }
            else if (T == "Settings")
            {
                if (!SettingsMenu.activeSelf) SettingsMenu.SetActive(true);

                // Settings Menu

            }
            else if (T == "Timer")
            {
                if (!TimerMenu.activeSelf) TimerMenu.SetActive(true);

                // Timer Menu

            }
        }
        else if (BoxType == 0) // Reset
        {
            BoxType = -1;
            Exit.SetActive(false);
            MusicMenu.SetActive(false);
            SettingsMenu.SetActive(false);
            TimerMenu.SetActive(false);
            BackSplash.SetActive(false);
        }
    }

    private void Update() // Update Method silly
    {
        // Open/Close Menu
        if (CTRL)
        {
            if (BoxType != 1 && BoxType != 2)
            {
                DialMenu.SetActive(!DialMenu.activeSelf); BoxType = 0;
                MainDial = true; SetAllArrays(1, true); SetAllArrays(2, false);
            }
            else
            {
                BoxType = 0;    
            }
        }
        // If there is an Open Menu
        else if (BoxType != -1) OpenAMenu();
        else
        {
            if (T != "") T = "";
            // If the Menu is open
            if (DialMenu.activeSelf)
            {
                // If Down is pressed
                if (D) { BoxType = 1; T = "Game"; } // Exit Game

                //If L is Pressed
                else if (L) Backpack(); // Toggle Backpack

                // If U is pressed
                else if (U)
                {
                    if (Top[1].activeSelf) { BoxType = 1; T = "Home"; } // Go Home 
                    else { BoxType = 2; T = "Timer"; } // Open Timer
                }

                //If R is Pressed
                else if (R)
                {
                    if (Right[1].activeSelf) { BoxType = 2; T = "Settings"; } // Open Settings Menu
                    else { BoxType = 2; T = "Music"; } // Open Music

                }
            }
        }
    }
}

/*
 * if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.transform.name + "");
                    switch (hit.transform.name)
                    {
                        case "Top":

                            break;
                        case "Left":
                            if (Menu.MainDial) //Is The BackPack Closed?
                                Menu.MainDial = false; //Open'er up!
                            else //If BackPack is Already Open
                                Debug.Log("");
                            break;
                        case "Right":

                            break;
                        case "Bottom":

                            break;
                    }
                }
            }
            */
