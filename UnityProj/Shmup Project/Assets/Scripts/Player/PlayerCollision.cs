using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {




	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "EnemyProjectile") {
		
			Destroy (gameObject);
		
		}


		if (c.GetComponent<PowerUpScript> () != null) {
		

			c.GetComponent<PowerUpScript> ().PowerUp ();
			Destroy (c.gameObject);
		
		}





		if (c.GetComponent<EnemyScript> () != null) {



			Destroy (gameObject);

		}

	}
}
