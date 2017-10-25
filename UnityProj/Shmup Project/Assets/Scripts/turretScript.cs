﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class turretScript : MonoBehaviour {



	public GameObject Pointer;
	public bool instant = true;
	public float AnglesPerSecond = 100f;
	bool tracking = true;
	Vector3 previous;
	public float SectorWidth = 170f;

	Vector3 StartVector;

	[Range(-180f, 180f)]
	public float baseRotation;

	// Use this for initialization
	void Start () {
		Quaternion Startrotation = Quaternion.Euler (0f,0f,baseRotation);
		transform.localRotation = Startrotation;

		StartVector = transform.up;

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 DirectionToPoint =  GameObject.Find ("Player").transform.position - transform.position;


		Vector3 minRotation = Quaternion.Euler (0f, 0f, -(SectorWidth/2))*StartVector;
		Vector3 maxRotation = Quaternion.Euler (0f, 0f, SectorWidth/2)*StartVector;

		float angle1 = Vector3.Angle (DirectionToPoint, minRotation);
		float angle2 = Vector3.Angle (DirectionToPoint, maxRotation);


		float currentRotation = Vector3.Angle (DirectionToPoint, StartVector);

		if (instant) {
		







			if (currentRotation < SectorWidth / 2) {
				transform.up = DirectionToPoint;
				tracking = true;


			} else if (tracking) {

				tracking = false;



				if (angle1 < angle2) {
				
					transform.up = minRotation;
				} else {
				
					transform.up = maxRotation;
				}


				previous = transform.up;
					

			} else {
			
				transform.up = previous;
			
			}

		
		} else {


			Vector3 targetVector;
		
			if (currentRotation < SectorWidth / 2) {
				targetVector = DirectionToPoint;
				tracking = true;


			} else if (tracking) {

				tracking = false;



				if (angle1 < angle2) {

					targetVector = minRotation;
				} else {

					targetVector = maxRotation;
				}


				previous = targetVector;


			} else {

				targetVector = previous;

			}




			float angleDifference = Vector3.Angle (transform.up, targetVector);

		//  var targetVector = DirectionToPoint;
		var newR = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation(transform.forward, targetVector), AnglesPerSecond * Time.deltaTime);
		// if (!(Quaternion.Angle(original, newR) > limit))
		transform.rotation = newR;



		}


	}
}
