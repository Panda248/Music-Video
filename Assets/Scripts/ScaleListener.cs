using System;
using UnityEngine;
public class ScaleListener : MonoBehaviour
{
    public enum Samples{
        Drums,
        Synths,
        Trumpet,
        ImNotACrook,
        Chorus,
        Vocals,
        Custom
    };

    [Tooltip("Pick a preset frequency range to listen to. " +
        "\nIf Custom is selected, the gameobject will use the range defined by freqMin and freqMax")]
    public Samples samples = Samples.Custom;
    public AudioSpectrum spectrumScript;
    
    [Range(0f, 11f)]
    public float freqMin;

    [Range(0f, 11f)]
    public float freqMax;
    public float floor = 1f;

    [Range(0f, 50f)]
    public float sensitivity = 1.0f;

    private int freqCount;
    private int freqMinAdjusted;
    private int freqMaxAdjusted;


    void Start()
    {
        if(spectrumScript == null)
        {
            spectrumScript = FindAnyObjectByType<AudioSpectrum>();
        }

        switch(samples)
        {
            case Samples.Drums:
                freqMinAdjusted = 0;
                freqMaxAdjusted = 150;
                break;
            case Samples.Synths:
                freqMinAdjusted = 100;
                freqMaxAdjusted = 1000;
                break;
            case Samples.ImNotACrook:
                freqMinAdjusted = 400;
                freqMaxAdjusted = 5000;
                break;
            case Samples.Chorus:
                freqMinAdjusted = 400;
                freqMaxAdjusted = 10000;
                break;
            case Samples.Vocals:
                freqMinAdjusted = 150;
                freqMaxAdjusted = 4000;
                break;
            default:
                freqMinAdjusted = (int)Mathf.Floor(Mathf.Pow(freqMin, (float)Math.E));
                freqMaxAdjusted = (int)Mathf.Floor(Mathf.Pow(freqMax, (float)Math.E));
                break;
        }

        freqMinAdjusted /= 44000 / spectrumScript.binCount;
        freqMaxAdjusted /= 44000 / spectrumScript.binCount;

        Debug.Log($"{gameObject.name} minBucket = {freqMinAdjusted} max = {freqMaxAdjusted}");

        freqCount = freqMaxAdjusted - freqMinAdjusted + 1;
    }

    // Update is called once per frame
    void Update()
    {
        float avg = 0;
        for (int i = freqMinAdjusted; i <= freqMaxAdjusted; i++)
        {
            avg += spectrumScript.getFrequency(i);
        }

        avg /= freqCount;

        float value = floor + (avg * sensitivity);

        transform.localScale = new Vector3(value, value, value);
    }
}
