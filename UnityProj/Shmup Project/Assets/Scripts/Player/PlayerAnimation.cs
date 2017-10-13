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
        Tilt();
    }

    private void Tilt()
    {
        float input = PlayerInput.verticalInput;

        Vector3 oldRotation = shipGraphics.transform.rotation.eulerAngles;

        Vector3 newRotation = oldRotation;
        newRotation.x += input * shipTiltSpeed;
        newRotation.x = Mathf.Clamp(newRotation.x, -shipTiltAmount, shipTiltAmount);

        shipGraphics.transform.rotation = Quaternion.Euler(newRotation);


    }
}
