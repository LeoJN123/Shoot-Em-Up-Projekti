using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldScript : MonoBehaviour {

    public GameObject particleExplosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}



	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "EnemyProjectile") {

            Destroy (c.gameObject);

            PlayerShield ps = GetComponentInParent<PlayerShield> ();
            ps.gatheredLaser += ps.laserTimePerProjectileHit;

            if (ps.gatheredLaser >= ps.maxLaserTime) {

            ps.gatheredLaser = ps.maxLaserTime;
            }

            GameObject pE = Instantiate(particleExplosion);
            pE.transform.position = c.transform.position;
            
		
		}


	}





    

}
