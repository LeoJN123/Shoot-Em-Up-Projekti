using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class World : MonoBehaviour {

    public static GameObject o;

    public GameObject cameraRig;

    public Vector3 positionFromCamera;

    private void Awake()
    {
        o = gameObject;
    }

    private void Update()
    {
        //transform.position = cameraRig.transform.position + positionFromCamera;
        //transform.rotation = cameraRig.transform.rotation;
    }
}
