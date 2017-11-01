using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public BoxCollider gameArea;

    Anchor anchor;

    public int playerSpeed;
    public float xClampDistance;
    public float yClampDistance;
    Rigidbody rb;

    private void Awake()
    {
        anchor = GetComponent<Anchor>();
    }

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

        var v3 = World.o.transform.TransformPoint(transform.position);
        v3.x = Mathf.Clamp(v3.x, leftBound, rightBound);
        v3.y = Mathf.Clamp(v3.y, bottomBound, topBound);
        v3.z = 0;
        transform.localPosition = World.o.transform.InverseTransformPoint(v3);
    }

    private void Movement()
    {
        var offset = transform.position - World.o.transform.position;
        var worldOffset = World.o.transform.InverseTransformVector(offset);
        Vector3 inputDirection = new Vector3(PlayerInput.horizontalInput, PlayerInput.verticalInput, 0);
        //if (worldOffset.x > xClampDistance && inputDirection.x > 0) {
        //    inputDirection.x = 0;
        //}
        //if(worldOffset.x < -xClampDistance && inputDirection.x < 0) {
        //    inputDirection.x = 0;
        //}
        //if (worldOffset.y > yClampDistance && inputDirection.y > 0) {
        //    inputDirection.y = 0;
        //}
        //if (worldOffset.y < -yClampDistance && inputDirection.y < 0) {
        //    inputDirection.y = 0;
        //}
        Vector3 localInputDirection = transform.InverseTransformDirection(inputDirection);
        Vector3 globalInputDirection = World.o.transform.TransformDirection(localInputDirection);
        anchor.lPos += globalInputDirection.normalized * playerSpeed * Time.deltaTime * 2f;

    }
}
