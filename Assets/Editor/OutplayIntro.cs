using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class OutplayIntro : EditorWindow
{
    static OutplayIntro() {
        EditorApplication.update += Update;
    }

    public static void Update()
    {
        EditorApplication.update -= Update;
        // Get existing open window or if none, make a new one:
        OutplayIntro window = (OutplayIntro)EditorWindow.GetWindow(typeof(OutplayIntro));
        window.Show();


    }
    void OnGUI()
    {
        GUILayout.Label("Hello Outplay recruiter! This is the submission for the Unity test, by Josh Lee.", EditorStyles.boldLabel);
        GUILayout.Label("As a reminder, you can find my portfolio here:");
        if (GUILayout.Button("Josh's portfolio")) Application.OpenURL("https://joshbe.me");

        GUILayout.Label("\n\nTip: Reduce asteroid count in the Asteroids GameObject");
    }
}