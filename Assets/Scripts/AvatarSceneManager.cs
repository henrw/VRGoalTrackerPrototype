using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarSceneManager : MonoBehaviour
{
    public GameObject avatar;
    // Start is called before the first frame update
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName.CompareTo("Basketball") == 0)
            avatar.SetActive(!TimeManager.exerciseHabit);
        else if (sceneName.CompareTo("Restaurant") == 0)
            avatar.SetActive(!TimeManager.foodHabit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
