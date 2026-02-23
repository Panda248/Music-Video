using System;
using UnityEngine;
public class ScaleListener : MonoBehaviour
{
    public enum Samples{
        SubBase,
        Bass,
        LowMid,
        Mid,
        UpperMid,
        Presence,
        Brilliance,
        WhoCanHearThis,
        Custom
    };

    [Tooltip("Pick a preset frequency range to listen to. " +
        "\nIf Custom is selected, the gameobject will use the range defined by freqMin and freqMax")]
    public Samples samples = Samples.Custom;
    public AudioSpectrum spectrumScript;
    
    [Range(0f, 44000)]
    public int freqMin;

    [Range(0f, 44000)]
    public int freqMax;
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
            case Samples.SubBase:
                freqMinAdjusted = 0;
                freqMaxAdjusted = 60;
                break;
            case Samples.Bass:
                freqMinAdjusted = 60;
                freqMaxAdjusted = 250;
                break;
            case Samples.LowMid:
                freqMinAdjusted = 250;
                freqMaxAdjusted = 500;
                break;
            case Samples.Mid:
                freqMinAdjusted = 500;
                freqMaxAdjusted = 2000;
                break;
            case Samples.UpperMid:
                freqMinAdjusted = 2000;
                freqMaxAdjusted = 4000;
                break;
            case Samples.Presence:
                freqMinAdjusted = 4000;
                freqMaxAdjusted = 6000;
                break;
            case Samples.Brilliance:
                freqMinAdjusted = 6000;
                freqMaxAdjusted = 20000;
                break;
            case Samples.WhoCanHearThis:
                freqMinAdjusted = 20000;
                freqMaxAdjusted = 44000;
                break;
            //case Samples.: // if you want to add more presets
            //    freqMinAdjusted = 150;
            //    freqMaxAdjusted = 4000;
            //    break;
            default:
                freqMinAdjusted = freqMin;
                freqMaxAdjusted = freqMax;
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
