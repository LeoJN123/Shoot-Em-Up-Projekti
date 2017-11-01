using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    public float speed;
    public float selfDestructionTime;
	public float damage = 1f;
    public GameObject[] particleEffects;

    private void Start()
    {
        Destroy(gameObject, selfDestructionTime);        
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        var dir = World.o.transform.InverseTransformDirection(World.o.transform.right);
        var globalDir = World.o.transform.TransformDirection(dir);
        transform.Translate(globalDir * speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(World.o.transform.right);
    }


    void OnTriggerEnter(Collider c)
	{
		if (c.GetComponent<EnemyScript> () != null) {
			c.GetComponent<EnemyScript> ().health -= damage;
			if (c.GetComponent<EnemyScript> ().health <= 0f) {


				c.GetComponent<EnemyScript> ().OnZeroHp ();


			
			
			}
		
			c.GetComponent<EnemyScript> ().IncreaseLuminosity ();


			GetComponent<Collider> ().enabled = false;
			Destroy (gameObject);

            foreach(GameObject particleEffect in particleEffects)
            {
                GameObject pE = Instantiate(particleEffect);
                pE.transform.position = transform.position;
            }

		}

	}

}
