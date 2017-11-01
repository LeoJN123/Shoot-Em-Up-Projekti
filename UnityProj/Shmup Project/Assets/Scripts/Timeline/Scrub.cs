using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scrub : MonoBehaviour {

    
    private void OnTriggerEnter(Collider other) {
        other.GetComponentInParent<Spawner>().Trigger();
    }
}
