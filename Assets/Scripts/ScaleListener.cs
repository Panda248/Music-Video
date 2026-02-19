using UnityEngine;
public class ScaleListener : MonoBehaviour
{
    public AudioSpectrum spectrumScript;
    public int freqMin;
    public int freqMax;
    public float floor = 1f;
    public float sensitivity = 1.0f;

    private int freqCount;

    void Start()
    {
        freqCount = freqMax - freqMin + 1;
    }

    // Update is called once per frame
    void Update()
    {
        float avg = 0;
        for (int i = freqMin; i <= freqMax; i++)
        {
            avg += spectrumScript.getFrequency(i);
        }

        avg /= freqCount;

        float value = floor + (avg * sensitivity);

        transform.localScale = new Vector3(value, value, value);
    }
}
