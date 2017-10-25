using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TimeLineEntry {
    public ITrigger trigger;
    public float time;
    public TimeLineEntry(ITrigger tr, float f) {
        trigger = tr;
        time = f;
    }
}
[ExecuteInEditMode]
public class TimeLine : MonoBehaviour {
    public List<TimeLineEntry> triggers = new List<TimeLineEntry>();
    float time;
    public static TimeLine instance;
	// Use this for initialization
	void Awake () {
        if (instance) {
            Debug.LogError("Too many timelines");
        }
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AddNewTrigger(ITrigger trigger) {
        if (triggers.Exists(x => x.trigger == trigger))
            return;

        var te = new TimeLineEntry(trigger, time);
        triggers.Add(te);
        triggers.Sort((x, y) => x.time.CompareTo(y.time)); // TODO: blah
    }
    public void RemoveTrigger(ITrigger trigger) {
        var te = triggers.FindIndex(x => x.trigger == trigger);
        if(te >= 0) {
            triggers.RemoveAt(te);
        }
    }
}
