using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMovement : MonoBehaviour {

	public Transform cameraPosition;
	float yspeed;
	float originalPositionY;
	public float acceleration;
	bool started;
	bool fade;
	float alpha;
	public float SecondsToFade = 3f;


	public Image fader;


	// Use this for initialization
	void Start () {

		originalPositionY = transform.position.y;

		fader.color = new Color (fader.color.r, fader.color.g, fader.color.b, 0f);


		
	}

	// Update is called once per frame
	void Update () {
	

		if (started) {
		
			acceleration += .1f;

			if (acceleration >= 12f) {
			
				fade = true;
			
			}

		}

		transform.Translate (3f+acceleration,0f,0f);
		cameraPosition.Translate (3f, 0f, 0f);


		if (transform.position.y > originalPositionY - 10f) {
		
			yspeed -= .025f;
		
		
		}

		if (transform.position.y < originalPositionY - 10f) {

			yspeed += .025f;


		}

		transform.Translate (0f,yspeed,0f);


		if (fade) {


			alpha += (1f/SecondsToFade) * Time.deltaTime;
			fader.color = new Color (fader.color.r, fader.color.g, fader.color.b, alpha);

			if (alpha >= 1f) {

				SceneLoader sl = GameObject.Find ("StartButton").GetComponent<SceneLoader> ();
			
				sl.SceneLoad (sl.SceneToLoad);
			
			}

		}


	}



	public void Activated()
	{
		fader.gameObject.SetActive (true);
		started = true;
	}
}
