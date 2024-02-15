using UnityEditor;
using UnityEngine;

public class TurnOffCameraProperties : EditorWindow
{
    [MenuItem("Tools/Turn Off Camera Properties")]
    static void TurnOffProperties()
    {
        // Get all GameObjects in the scene
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // Check if the GameObject has a Camera component
            Camera cameraComponent = obj.GetComponent<Camera>();

            if (cameraComponent != null)
            {
                // Disable the Camera component
                cameraComponent.enabled = false;
            }
        }

        Debug.Log("All camera properties turned off.");
    }
}