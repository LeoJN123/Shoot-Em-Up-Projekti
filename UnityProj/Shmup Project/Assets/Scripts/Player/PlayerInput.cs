using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour {

    
    //Movement input
    public static float horizontalInput = 0;
    public static float verticalInput = 0;

    public static event Action Shoot;
	public static event Action Shield;
	public static event Action noShield;

    GameObject player;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (player) {
            if (Input.GetButton("Fire") || Input.GetAxisRaw("Fire") > 0) {
                CheckForNullAndRun(Shoot);
            }

            if (Input.GetButton("Shield")) {
                CheckForNullAndRun(Shield);
            } else {
                CheckForNullAndRun(noShield);
            }
        }
    }


    //Makes sure that the action that is being called is not null aka has no subscribers
    //boo! It's october 30th
    void CheckForNullAndRun(Action action)
    {
        if (action != null)
        {
            action();
        }
    }

}
