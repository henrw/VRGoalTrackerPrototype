using UnityEditor;
using UnityEngine;

public class TurnOffAllLights : EditorWindow
{
    [MenuItem("Tools/Turn Off All Lights")]
    static void TurnOffLights()
    {
        Light[] lights = FindObjectsOfType<Light>();

        foreach (Light light in lights)
        {
            light.enabled = false;
        }
    }
}