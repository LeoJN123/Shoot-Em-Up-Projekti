using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyTurret : MonoBehaviour {



	Vector3 DirectionToPoint = new Vector3 (0f, 0f, 0f);
	public bool instant = true;
	public float AnglesPerSecond = 100f;
	public float SecondsBetweenShots= 2f;
	public float turretLength = 1f;
	public float shotSpeed = .25f;
	public float projectileDecayTime = 10f;
	public GameObject projectile;
	float shotTimer;
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

		GetComponent<TurretEditorDisplay> ().display = false;


	}
	
	// Update is called once per frame
	void Update () {


		if (GameObject.Find ("Player") != null) {
			DirectionToPoint = GameObject.Find ("Player").transform.position - transform.position;
		}


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


		shotTimer += Time.deltaTime;

		if (shotTimer > SecondsBetweenShots) {

			shotTimer -= SecondsBetweenShots;

			GameObject shot = Instantiate (projectile);

			Vector3 direction = transform.up.normalized;

			shot.transform.position = transform.position + direction * turretLength;
			shot.GetComponent<ProjectileMovement>().velocity = direction * shotSpeed*20f*Time.deltaTime;

			Destroy (shot.gameObject, projectileDecayTime );

		}




	}


	void OnApplicationQuit()
	{
		GetComponent<TurretEditorDisplay> ().display = true;
	}
}
