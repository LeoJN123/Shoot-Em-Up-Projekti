using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTrack : MonoBehaviour {
    
    public Transform start;
    public Transform end;
    public float totalTime;

    public void MoveCamera(float time)
    {
        transform.position = Vector3.Lerp(start.position, end.position, time / totalTime);
        transform.rotation = Quaternion.Slerp(start.rotation, end.rotation, time / totalTime);
        
    }

}
