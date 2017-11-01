using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

    public ParticleSystem[] particleSys;

	Vector3 Startposition;
	float timePassed;
    float maxDuration;
    public bool shake;

	// Use this for initialization
	void Start () {

		particleSys = GetComponentsInChildren<ParticleSystem>();
        
        

        foreach (ParticleSystem ps in particleSys) 
        {
            float duration = ps.main.duration + ps.main.startLifetimeMultiplier;

            if (duration > maxDuration)
            {
                maxDuration = duration;
            }

            print(duration);

        }

		Startposition = transform.position;


	}
	
	// Update is called once per frame
	void Update () {
		timePassed += Time.deltaTime;

        if (shake)
        {
            transform.position = new Vector3(Startposition.x + Random.Range(-timePassed / 4f, timePassed / 4f), Startposition.y + Random.Range(-timePassed / 4f, timePassed / 4f), Startposition.z + Random.Range(-timePassed / 4f, timePassed / 4f));
        }

		if (timePassed > maxDuration) {
			Destroy (gameObject);
		
		}
	}




}
