using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour {

	public GameObject projectileShield;
	public GameObject chargeLaser;
	GameObject shield;
	GameObject laser;
	bool ableToShield = true;
	bool shieldFading;
	public bool laserFiring;
	public float secondsToShield = 30f;
	public float shieldUpTime = 5f;

	public float laserTimePerProjectileHit = .2f;
	public float maxLaserTime = 5f;
	public float gatheredLaser = 0f;


	public float shieldCharge;

	// Use this for initialization
	void Start () {

		shieldCharge = secondsToShield;

		SubscribeToEvents ();
	}
	
	// Update is called once per frame
	void Update () {


		if (shieldCharge < secondsToShield || shieldFading) {


			if (!shieldFading && !laserFiring) {

				shieldCharge += Time.deltaTime;

			} else {

				if (!laserFiring) {
			
					shieldCharge -= Time.deltaTime * (secondsToShield / (secondsToShield / shieldUpTime));
				}

				if (shieldCharge <= 0f) {

					CloseShield ();
				}
					
			}
		} else {
		
			shieldCharge = secondsToShield;
		}



	}



	public void CreateShield ()
	{

		if (shieldCharge >= secondsToShield && !shieldFading) {

			shield = Instantiate (projectileShield);
			shield.transform.position = transform.position;
			shield.transform.parent = transform;
			shieldFading = true;
		

		
		}

		


	}


	public void CloseShield ()
	{
		if (shieldFading) {
			Destroy (shield.gameObject);
			shieldUpTime = 5f;
			shieldFading = false;

			laser = Instantiate (chargeLaser);
			laser.transform.position = GetComponent<PlayerShoot> ().shipTurretPoint.transform.position + new Vector3 (laser.transform.localScale.x / 2f, 0f, 0f);
			laser.transform.parent = GetComponent<PlayerShoot> ().shipTurretPoint.transform;

			laser.GetComponent<laserScript> ().laserUptime = gatheredLaser;

			laserFiring = true;
			gatheredLaser = 0f;

		}




	}

	public void SubscribeToEvents ()
	{

		PlayerInput.Shield += CreateShield;
		PlayerInput.noShield += CloseShield;

	}
}
