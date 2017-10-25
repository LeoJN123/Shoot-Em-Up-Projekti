using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public BoxCollider gameArea;

    public int playerSpeed;

    Rigidbody rb;

    private void FixedUpdate()
    {
        Movement();
        //ClampToBounds();
    }

    private void ClampToBounds()
    {
        Bounds bounds = gameArea.bounds;

        float leftBound = bounds.min.x;
        float rightBound = bounds.max.x;
        float bottomBound = bounds.min.y;
        float topBound = bounds.max.y;

        var v3 = transform.localPosition;
        v3.x = Mathf.Clamp(v3.x, leftBound, rightBound);
        v3.y = Mathf.Clamp(v3.y, bottomBound, topBound);
        v3.z = 0;
        transform.localPosition = World.o.transform.InverseTransformPoint(v3);
    }

    private void Movement()
    {

        Vector2 inputDirection = new Vector2(PlayerInput.horizontalInput, PlayerInput.verticalInput).normalized;
        Vector2 localInputDirection = transform.InverseTransformDirection(inputDirection);
        Vector2 globalInputDirection = World.o.transform.TransformDirection(localInputDirection);
        transform.Translate(globalInputDirection * playerSpeed * Time.deltaTime * 2, Space.Self);
    }
}
