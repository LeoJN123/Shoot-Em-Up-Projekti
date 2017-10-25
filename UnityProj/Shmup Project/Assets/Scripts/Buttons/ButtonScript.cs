using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {
	bool asd = false;
	public bool Enabled = false;
	float originX;
	float originY;

	public float currentX;
	public float currentY;


	// Use this for initialization
	void Start () {
		originX = transform.position.x;
		originY = transform.position.y;



	}
	
	// Update is called once per frame
	void Update () {

		if (!asd) {
			gameObject.SetActive (Enabled);
			asd = true;
		}

		transform.position = new Vector3 (originX + currentX, originY + currentY, 0f);

	}
}
