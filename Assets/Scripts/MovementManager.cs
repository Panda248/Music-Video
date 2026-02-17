using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MovementManager : MonoBehaviour
{

    [Serializable] class Movement { public float start; public GameObject movementObject; }
    AudioSource audio;
    float time;

    [SerializeField] List<Movement> movements;
    int currentMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
        if(movements == null)
        {
            movements = new List<Movement>();
        }
        currentMovement = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time = audio.time;
        
    }

    float remainingMovementDuration()
    {
        if(currentMovement == movements.Count)
        {
            return -1;
        }
        return time - movements[currentMovement + 1].start;
    }

    float currentMovementDuration()
    {
        return movements[currentMovement + 1].start - movements[currentMovement].start;
    }
}
