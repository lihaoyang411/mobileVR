using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class FacePlayer : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }

}
