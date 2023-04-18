using UnityEditor;
using UnityEngine;

public class DebugConsole : EditorWindow
{
    [MenuItem("Window/Debug Console")]
    public static void ShowWindow()
    {
        GetWindow<DebugConsole>("Debug");
    }
    private void OnGUI()
    {
        GUILayout.Label("Debug Console", EditorStyles.boldLabel);

        if (GUILayout.Button("Take ScreenShot"))
        {
            FindObjectOfType<TakeScreenShot>().TakeScreenshot();
        }
    }

   
    
}