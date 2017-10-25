using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour {

    
    //Movement input
    public static float horizontalInput = 0;
    public static float verticalInput = 0;

    public static event Action Shoot;


    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetButton("Fire"))
        {
            CheckForNullAndRun(Shoot);
        }
    }

    void CheckForNullAndRun(Action action)
    {
        if (action != null)
        {
            action();
        }
    }

}
