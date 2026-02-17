using UnityEngine;

[RequireComponent (typeof(Light))]
public class LightListener : MonoBehaviour
{
    public AudioSpectrum spectrumScript;
    public int freqMin;
    public int freqMax;
    public float lightFloor = 1f;
    public float scale = 1.0f;

    private Light lightComp;
    private int freqCount;

    void Start()
    {
        lightComp = GetComponent<Light>();
        freqCount = freqMax - freqMin + 1;
    }

    // Update is called once per frame
    void Update()
    {
        float avg = 0;
        for(int i = freqMin; i <= freqMax; i++)
        {
            avg += spectrumScript.getFrequency(i);
        }

        avg /= freqCount;

        lightComp.intensity = lightFloor + (avg * scale);
    }
}
