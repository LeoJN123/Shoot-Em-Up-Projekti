using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class TurretEditorDisplay : MonoBehaviour {


	public bool display = true;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (display) {
			Quaternion Startrotation = Quaternion.Euler (0f, 0f, GetComponent<EnemyTurret> ().baseRotation);
			transform.localRotation = Startrotation;
		}
	}
}
