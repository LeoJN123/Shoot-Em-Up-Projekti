using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public float health = 10f;
	Renderer R;
	Color Startcolor;
	float lum = 0f;
	public GameObject PowerUp;
	[Range(0f,100f)]
	public float dropChance = 10f;

	// Use this for initialization
	void Start () {
		R = GetComponent<Renderer> ();
		Startcolor = R.material.color;
		GetComponent<Rigidbody> ().isKinematic = true;
		GetComponent<Rigidbody> ().useGravity = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (lum > 1f) {
		
			lum -= 10f * Time.deltaTime;
		
		} else {
			lum = 1f;
		
		}


		R.material.color = new Color (Startcolor.r * lum, Startcolor.g * lum, Startcolor.b * lum);



	}






	public void IncreaseLuminosity()
	{

		lum = 3f;
	}





	public void OnZeroHp()
	{
		GetComponent<Collider> ().enabled = false;
		//animaatioscripticallihommat vielä tähän


		//esim

		//if(GetComponent<animaatioskriptin nimi>().deathAnimation = null)
		//{
		OnEnemyDestroy ();
		//}else{

		//GetComponent<animaatioskriptin nimi>().ExecuteDeathAnimation();

		//}

	}

	public void OnEnemyDestroy()
	{

		//kutsutaan kuolemisanimaati	on loppuessa

		if (GetComponent<Meteor> () != null) {
		
			GetComponent<Meteor> ().Destroyed();
		
		
		}


		float randomNumber = Random.Range (0f, 100f);

		if (randomNumber < dropChance) {

			if (PowerUp != null) {
				GameObject pUp = Instantiate (PowerUp);
				pUp.transform.position = transform.position;
			}
		}

		Destroy (gameObject);


	}

}
