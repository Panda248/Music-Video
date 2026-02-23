using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GirlAnimationScript : MonoBehaviour
{
    public float blinkInterval = 10;
    public List<float> times;

    private Animator animator;
    private float blinkTimer;
    private bool smiling;
    private int currentIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        if(times == null) times = new List<float>();
        blinkTimer = blinkInterval;

        smiling = false;
        currentIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentIndex < times.Count)
        {
            float curTimeStamp = AudioSpectrum.getAudio().time;

            if(curTimeStamp >= times[currentIndex])
            {
                currentIndex++;
                smiling = !smiling;
                animator.SetBool("Smiling", smiling);
            }
        }

        blinkTimer -= Time.deltaTime;
        if(blinkTimer < 0)
        {
            animator.ResetTrigger("Blink");
            blinkTimer = blinkInterval;
            animator.SetTrigger("Blink");
        }


    }
}
