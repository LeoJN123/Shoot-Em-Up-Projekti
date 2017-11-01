using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour {

    //Change these in order to move & rotate stuff on the stage
    public Vector3 lPos;
    public Quaternion lRot;

    private void Update()
    {
        AnchorObjectToScene();
    }

    void AnchorObjectToScene()
    {
        transform.rotation = World.o.transform.rotation;
        transform.position = World.o.transform.TransformPoint(lPos);
    }
}
