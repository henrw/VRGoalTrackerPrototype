using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip foodGood;
    public AudioClip foodBad;
    public AudioClip basketballStart;
    public AudioClip basketballKeep;
    public AudioClip basketballEnd;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TimeManager.state = TimeManager.State.Idle;
            TimeManager.time += 1;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            if (TimeManager.state == TimeManager.State.Food)
                TimeManager.foodHealthy = true;
            else if (TimeManager.state == TimeManager.State.Exercise)
                TimeManager.isExercise = true;
        }
        if (TimeManager.state == TimeManager.State.Food)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                audioSource.clip = foodGood;
                audioSource.Play();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                audioSource.clip = foodBad;
                audioSource.Play();
            }
        }
        else if (TimeManager.state == TimeManager.State.Exercise)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                audioSource.clip = basketballStart;
                audioSource.Play();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                audioSource.clip = basketballKeep;
                audioSource.Play();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                audioSource.clip = basketballEnd;
                audioSource.Play();
            }
        }
    }
}
