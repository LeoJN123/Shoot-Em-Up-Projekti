using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TimeLineEntry {
    public Spawner trigger;
    public float time;
    public TimeLineEntry(Spawner tr, float f) {
        trigger = tr;
        time = f;
    }
}
[ExecuteInEditMode]
public class TimeLine : MonoBehaviour {
    public List<TimeLineEntry> triggers = new List<TimeLineEntry>();
    public GameObject scrub;
    public Transform triggerContainer;
    public LevelTrack lt;
    float time;
    bool gameRunning;


    static TimeLine _instance;
    public static TimeLine instance {
        get {
            if (_instance == null) {
                _instance = GameObject.Find("Timeline").GetComponent<TimeLine>();
            }
            return _instance;
        }
    }
    private void Awake() {
        if (Application.isPlaying)
            StartLevel();
    }
    void StartLevel() {
        gameRunning = true;
    }
    private void Update() {
        time = Vector3.Distance(transform.position, scrub.transform.position);
        if (Application.isEditor && !Application.isPlaying) {
            lt.MoveTrack(time, scrub);
            if (Vector3.Distance(transform.position, scrub.transform.position) < 1) {
                lt.waypointIndex = 0;
            }
        }
    }
    private void FixedUpdate() {
        if (gameRunning) {
            scrub.transform.position += transform.right * Time.deltaTime;
            lt.MoveTrack(time, scrub);
        }
    }
    public void AddNewTrigger(Spawner trigger) {
        if(triggers.Count > 0) {
            for (int i = triggers.Count -1; i >= 0; i--) {
                if (triggers[i].trigger == null) {
                    triggers.RemoveAt(i);
                }
            }
        }
        
        if (triggers.Exists(x => x.trigger == trigger)) {
            print("trigger exists");
            return;
        }
        print("creating new trigger");
        var te = new TimeLineEntry(trigger, time);
        triggers.Add(te);
        triggers.Sort((x, y) => x.time.CompareTo(y.time)); // TODO: blah
    }
    public void RemoveTrigger(Spawner trigger) {
        var te = triggers.FindIndex(x => x.trigger == trigger);
        if(te >= 0) {
            triggers.RemoveAt(te);
        }
    }
    [UnityEditor.Callbacks.DidReloadScripts]
    public static void OnScriptsReloaded() {
        Debug.Log("Finished compiling");
        print("instance is now null? " + (instance == null));
        
    }
}
