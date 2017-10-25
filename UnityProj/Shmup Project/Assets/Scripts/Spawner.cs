using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Spawner : MonoBehaviour, ITrigger {

	// Use this for initialization
	void Start () {
        if (Application.isEditor && !Application.isPlaying) {
            TimeLine.instance.AddNewTrigger(this);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Trigger() {
        print("triggered");

    }
}
