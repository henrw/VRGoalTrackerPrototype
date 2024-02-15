using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string sceneNameToLoad;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider is tagged as Player (or any other condition you'd like)
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
