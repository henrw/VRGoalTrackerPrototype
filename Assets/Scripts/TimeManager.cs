using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.UIElements;

public class TimeManager : MonoBehaviour
{

    public Animator exerciseAnimator;
    public Animator foodAnimator;
    public enum State
    {
        Idle,
        Food,
        Exercise
    };
    
    public GameObject lebronAvatar;
    public GameObject ramsayAvatar;
    public SceneSwitcher sceneSwitcher;
    static bool animationPlayed = false;
    static int foodStartTime = 12;
    static int foodEndTime = 13;
    static int ExerciseStartTime = 17;
    static int ExerciseEndTime = 18;

    public static State state = State.Idle;
    static float speed1 = 0.01f;
    static float speed2 = 0.0005f;
    public static float time = 0; // in hours
    public static bool isExercise = false;
    public static bool exerciseHabit = false;
    public static bool foodHabit = false;
    public static bool foodHealthy = false;
    public float failTimeBasketball = 0;
    private static int days = 0;
    public Image layerBottom;
    public Image layerOne;
    public Image layerTwo;
    public Image layerThree;
    public Image layerFour;
    public AudioClip basketballIntro;
    public AudioClip foodIntro;
    public GameObject portal;

    // Update is called once per frame
    void Start()
    {
        lebronAvatar.SetActive(!exerciseHabit);
        ramsayAvatar.SetActive(!foodHabit);
    }
    void Update()
    {
        UpdateTime();

        // Play Animation
        if (state == State.Idle && animationPlayed)
        {
            if (time < ExerciseStartTime)
                foodAnimator.SetTrigger("TriggerResetRamsay");
            else
                exerciseAnimator.SetTrigger("TriggerResetLebron");
            animationPlayed = false;
        }
        else if (state == State.Exercise && !animationPlayed)
        {
            if (!exerciseHabit)
            {
                exerciseAnimator.SetTrigger("TriggerPlayLebron");
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.clip = basketballIntro;
                audioSource.Play();
            }
            
            animationPlayed = true;
            sceneSwitcher.sceneNameToLoad = "Basketball";
            portal.SetActive(true);
            
        }
        else if (state == State.Food && !animationPlayed)
        {
            if (!foodHabit)
            {
                foodAnimator.SetTrigger("TriggerPlayRamsay");
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.clip = foodIntro;
                audioSource.Play();
            }
            
            animationPlayed = true;
            sceneSwitcher.sceneNameToLoad = "Restaurant";
            portal.SetActive(true);
        }
    
        // Draw line
        layerTwo.fillAmount = Math.Min(time, ExerciseStartTime) / 24f;
        layerFour.fillAmount = Math.Min(time, foodStartTime) / 24f;
        layerBottom.fillAmount = time / 24f;
        if (!foodHealthy)
        {
            layerThree.fillAmount = Math.Min(time, foodEndTime) / 24f;
        }
        else
        {
            layerFour.fillAmount = Math.Min(time, foodEndTime) / 24f;
        }
        if (!isExercise)
        {
            layerOne.fillAmount = Math.Min(time, ExerciseEndTime) / 24f;
        }
        else
        {
            layerTwo.fillAmount = Math.Min(time, foodEndTime) / 24f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            state = State.Idle;
            time += 1;
            portal.SetActive(false);
            // exerciseAnimator.SetTrigger("TriggerResetLebron");
            // foodAnimator.SetTrigger("TriggerResetRamsay");
            // animationPlayed = false;

        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (isExercise)
                exerciseHabit = true;
            else
                exerciseHabit = false;
            if (foodHealthy)
                foodHabit = true;
            else
                foodHabit = false;

            lebronAvatar.SetActive(!exerciseHabit);
            ramsayAvatar.SetActive(!foodHabit);
            time = 9;
            days += 1;
            foodHealthy = false;
            isExercise = false;
        }
        
    }
    void UpdateTime()
    {
        if (time >= 24f)
        {
            time = 24;
            return;
        }

        if (time > ExerciseEndTime)
        {
            state = State.Idle;
        }
        else if (time > ExerciseStartTime)
        {
            state = State.Exercise;
        }
        else if (time > foodEndTime)
        {
            state = State.Idle;
        }
        else if (time > foodStartTime)
        {
            state = State.Food;
            
        }
        

        if (state == State.Idle)
        {
            if (time > ExerciseEndTime)
                time += speed1*10;
            else
                time += speed1;
        }
        // else
        // {
        //     time += speed2;
        // }

        // TakeKeyInputs();
    }
}
