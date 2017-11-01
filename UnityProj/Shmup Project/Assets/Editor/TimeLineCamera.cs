using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

class TimeLineCamera : EditorWindow {
    [MenuItem("Window/Timeline Camera")]
    public static void ShowWindow() {
        EditorWindow.GetWindow(typeof(TimeLineCamera));
    }
    private void OnGUI() {
        
    }
}
