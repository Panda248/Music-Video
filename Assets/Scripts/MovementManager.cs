using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MovementManager : MonoBehaviour
{

    [Serializable] class Movement { public float start; public GameObject movementObject; }
    AudioSource audiosource;

    [SerializeField] List<Movement> movements;
    [SerializeField] Movement currentMovement;
    int nextMovement;
    float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0;
        audiosource = AudioSpectrum.getAudio();
        if(movements == null)
        {
            movements = new List<Movement>();
        }
        nextMovement = 0;
        currentMovement.movementObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        time = audiosource.time;
        Debug.Log(time);
        if (nextMovement < movements.Count)
        {
            if(time > movements[nextMovement].start)
            {
                Debug.Log($"Moving from {currentMovement.ToString()} to {movements[nextMovement].ToString()}");
                currentMovement.movementObject.SetActive(false);

                currentMovement = movements[nextMovement];
                currentMovement.movementObject.SetActive(true);
                nextMovement++;
            }
        }
        
    }

    float remainingMovementDuration()
    {
        if(nextMovement == movements.Count)
        {
            return -1;
        }
        return time - movements[nextMovement].start;
    }

    float currentMovementDuration()
    {
        return movements[nextMovement].start - ((nextMovement == 0) ? 0 : movements[nextMovement - 1].start);
    }
}
