using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour {

    public float speed;
    public float selfDestructionTime;

    private void Start()
    {
        Destroy(gameObject, selfDestructionTime);        
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }
}
