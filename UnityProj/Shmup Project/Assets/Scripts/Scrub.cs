using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Scrub : MonoBehaviour {

    bool gameRunning;

    cameraTrack cTS;

	public void StartLevel()
    {
        gameRunning = true;
        //
    }

    private void Update()
    {
        if (Application.isEditor && !Application.isPlaying)
        {
            cTS.MoveCamera(Vector3.Distance(transform.position, transform.parent.position));
        }
        else if (gameRunning)
        {
            transform.position += transform.parent.right * Time.deltaTime;
            cTS.MoveCamera(Vector3.Distance(transform.position, transform.parent.position));
        }
    }

    private void Start()
    {
        if (Application.isPlaying)
            StartLevel();
        cTS = GameObject.Find("Cameras").gameObject.GetComponent<cameraTrack>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var a = other.GetComponent<ITrigger>();
        a.Trigger();
    }

}
