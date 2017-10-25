using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldAnchor : MonoBehaviour {

    private void Update()
    {
        transform.rotation = World.o.transform.rotation;
        transform.position = World.o.transform.position;
    }
}
