using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour {

    public GameObject particleEffect;
    GameObject pE;
	public float laserUptime;

	// Use this for initialization
	void Start () {

        pE = Instantiate(particleEffect);
        pE.transform.parent = GameObject.Find("Player").transform;
        pE.transform.position = GetComponentInParent<PlayerShoot>().shipTurretPoint.transform.position - new Vector3(.4f,0f,0f);



       
		
	}
	
	// Update is called once per frame
	void Update () {
		laserUptime -= Time.deltaTime;

		if (laserUptime <= 0f) {
		
			Destroy (gameObject);
			GetComponentInParent<PlayerShield> ().laserFiring = false;
            Destroy (pE.gameObject);
		}
	}
}
