using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor {

    void OnSceneGUI() {
        Spawner actor = target as Spawner;
        Event e = Event.current;
        switch (e.type) {
            case EventType.keyDown: {
                    if (Event.current.keyCode == (KeyCode.Tab)) {
                        GameObject scrub = GameObject.Find("Scrub");
                        actor.transform.position = World.o.transform.position;
                        var marker = actor.GetComponent<Spawner>().marker;
                        marker.transform.position = scrub.transform.position;
                    }
                }
        if (e.type == EventType.ExecuteCommand || e.type == EventType.ValidateCommand) {
            if (e.commandName == "SoftDelete") {
                Debug.Log(target.name + " is deleted");
            }
        }
        break;
        }
    }
}
