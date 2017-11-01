using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrack : MonoBehaviour {
    public Transform[] waypoints;
    public float timeBetweenWaypoints;
    [HideInInspector]
    public int waypointIndex = 0;
    float tolerance = 0.5f;

	void Start () {
		
	}
	
	void Update () {

    }

    //loop?
    public void MoveTrack(float time, GameObject scrub) {
        if(waypointIndex < waypoints.Length - 1) {
            transform.position = Vector3.Lerp(waypoints[waypointIndex].position, waypoints[waypointIndex + 1].position, (time - timeBetweenWaypoints * waypointIndex) / timeBetweenWaypoints);
            transform.rotation = Quaternion.Slerp(waypoints[waypointIndex].rotation, waypoints[waypointIndex + 1].rotation, (time - timeBetweenWaypoints * waypointIndex) / timeBetweenWaypoints);
            if (Vector3.Distance(transform.position, waypoints[waypointIndex + 1].position) < tolerance) {
                if (waypointIndex < waypoints.Length) {
                    waypointIndex++;
                }
            }
        }
    }
}
