using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Spawner : MonoBehaviour {
    Transform spawners;
    Vector3 lPos;
    public GameObject marker;

    void Start () {
        
        if (Application.isEditor && !Application.isPlaying) {
            TimeLine.instance.AddNewTrigger(this);
            spawners = GameObject.Find("SpawnerContainer").transform;
            transform.SetParent(spawners);
        }
        if (Application.isPlaying) {
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
    public void Trigger() {
        var trigger = GetComponent<ITrigger>();
        if (trigger != null) {
            trigger.Trigger();
        } else {
            Debug.LogWarning("No trigger in spawner");
        }
    }
    public void Remove() {
        TimeLine.instance.RemoveTrigger(this);
    }
    void OnDestroy() {
        if (Event.current != null && Event.current.commandName == "SoftDelete")
            Remove();
    }
}
