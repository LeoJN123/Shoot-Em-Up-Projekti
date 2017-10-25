using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyProjectile : MonoBehaviour {

    Vector3 lPos;
    Quaternion lRot;

    GameObject origin;

    private void Update()
    {
        lPos += Vector3.right * Time.deltaTime * 0.1f;


        transform.rotation = World.o.transform.rotation * lRot;
        transform.position = origin.transform.TransformPoint(lPos);
    }
    private void Start()
    {
        origin = World.o;
        var wt = origin.transform;

        lPos = wt.InverseTransformPoint(transform.position);
        lRot = Quaternion.Inverse(World.o.transform.rotation) * transform.rotation;
    }
}
