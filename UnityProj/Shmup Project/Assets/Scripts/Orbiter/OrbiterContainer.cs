using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbiterContainer : MonoBehaviour {

    public float orbitSpeed;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 5) * orbitSpeed * Time.deltaTime);
    }
}
