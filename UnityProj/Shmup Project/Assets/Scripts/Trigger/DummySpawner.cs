using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummySpawner : MonoBehaviour, ITrigger {

    public GameObject dummyObject;

	public void Trigger()
    {
        SpawnStuff();
    }

    private void SpawnStuff()
    {
        Instantiate(dummyObject, World.o.transform.position, World.o.transform.rotation * Quaternion.Euler(15,0,0), null);
    }
}
