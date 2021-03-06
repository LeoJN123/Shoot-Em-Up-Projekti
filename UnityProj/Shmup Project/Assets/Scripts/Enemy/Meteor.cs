﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {
	public GameObject fragment;
	public GameObject Explosion;
	public int fragments = 3;
	public float fragmentSpeed = .1f;




	[Range(0f,360f)]

	public float SectorWidth = 120f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GetComponent<Anchor>().lPos += -Vector3.right * Time.deltaTime;
	}

	public void Destroyed()
	{

		for (int i = 0; i < fragments; i++) {
		
			GameObject Frag = Instantiate (fragment);
			Frag.transform.position = transform.position;

			Vector3 velocity = (GameObject.Find ("Player").transform.position-transform.position).normalized;
			float angle = Random.Range (SectorWidth/2-SectorWidth,SectorWidth/2);

			velocity = Quaternion.Euler (0f, 0f, angle) * velocity;

			Frag.GetComponent<ProjectileMovement> ().velocity = velocity * (fragmentSpeed * Random.Range (.8f, 1.2f) * Time.deltaTime * 50f);





		}

		GameObject Sploder = Instantiate (Explosion);
		Sploder.transform.position = transform.position;

	}

}
