using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMenuController : MonoBehaviour
{
    public float SwipeThreshold = 0.5f;

    private Vector2 _startingPosition;
    private Vector2 _currentPosition; 
    private bool _startedTouch; 

    void Start()
    {
        _startedTouch = false;
        _startingPosition = GvrControllerInput.TouchPosCentered;
        _currentPosition = GvrControllerInput.TouchPosCentered;
    }

    void Update()
    {
        if (GvrControllerInput.AppButtonDown)
            Menu.CTRL = true;
        else
            if (Menu.CTRL) Menu.CTRL = false;


        if (GvrControllerInput.IsTouching)
        {
            if (!_startedTouch)
            {
                _startedTouch = true;
                _startingPosition = GvrControllerInput.TouchPos;
                _currentPosition = GvrControllerInput.TouchPos;
            }
            else
            {
                _currentPosition = GvrControllerInput.TouchPos;
            }
        }
        else
        {
            if (_startedTouch)
            {
                _startedTouch = false;
                Vector2 delta = _currentPosition - _startingPosition;
                DetectSwipe(delta);
            }
        }
    }
    private void DetectSwipe(Vector2 delta)
    {
        float y = delta.y;
        float x = delta.x;
        
        if (y > 0 && Mathf.Abs(x) < SwipeThreshold)
        {
            Menu.D = true;
        }

        if (y < 0 && Mathf.Abs(x) < SwipeThreshold)
        {
            Menu.U = true;
        }

        if (x > 0 && Mathf.Abs(y) < SwipeThreshold)
        {
            Menu.R = true;
        }

        if (x < 0 && Mathf.Abs(y) < SwipeThreshold)
        {
            Menu.L = true;
        }

        Menu.D = false;
        Menu.L = false;
        Menu.R = false;
        Menu.U = false;
    }
}


/*
public class TempMenuController : MonoBehaviour
{


    /// <summary>
    /// 
    /// Important: Change the first if statement's condition to match input of whatever controller you use
    /// 
    /// </summary>

    private void Start()
    {
        if (GameObject.FindGameObjectsWithTag("MainCamera").Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }



    void Update()
    {
        if (GvrControllerInput.AppButtonDown)
            Menu.CTRL = true;
        else
            if (Menu.CTRL) Menu.CTRL = false;

      


        if (Input.GetKeyDown(KeyCode.RightArrow))
            Menu.R = true;
        else
            if (Menu.R) Menu.R = false;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Menu.L = true;
        else
            if (Menu.L) Menu.L = false;

        if (Input.GetKeyDown(KeyCode.UpArrow))
            Menu.U = true;
        else
            if (Menu.U) Menu.U = false;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            Menu.D = true;
        else
            if (Menu.D) Menu.D = false;
    }
}
*/