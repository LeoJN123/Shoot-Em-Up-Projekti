using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public GameObject shipGraphics;

    Quaternion defaultRotation;
    public float shipTiltAmount;
    public float shipTiltSpeed;

    public float thrusterMax;
    public float thrusterMin;

    private void Start()
    {
        defaultRotation = shipGraphics.transform.rotation;
    }

    private void Update()
    {
        if (PlayerInput.verticalInput > 0)
        {
            print("Going up");


        }

        if (PlayerInput.verticalInput < 0)
        {
            print("Going Down");


        }
    }

    private void Tilt(bool up)
    {

    }
}
