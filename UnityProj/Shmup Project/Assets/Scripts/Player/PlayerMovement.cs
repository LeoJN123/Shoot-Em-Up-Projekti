using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public int playerSpeed;

    Rigidbody2D rb;

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {

        Vector2 inputDirection = new Vector2(PlayerInput.horizontalInput, PlayerInput.verticalInput).normalized;
        transform.Translate(inputDirection * playerSpeed * Time.deltaTime * 2);

    }
}
