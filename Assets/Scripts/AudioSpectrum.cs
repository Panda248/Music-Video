using System.ComponentModel;
using UnityEngine;


[RequireComponent (typeof(AudioSource))]
public class AudioSpectrum : MonoBehaviour
{
    public int binCount = 256;

    static AudioSource source;
    private float[] spectrum;


    public static AudioSource getAudio()
    {
        if (source == null)
        {
            source = FindFirstObjectByType<AudioSource>();
        }
        return source;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
        spectrum = new float[binCount];
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        source.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);

        //for (int i = 1; i < spectrum.Length - 1; i++)
        //{
        //    Debug.DrawLine(new Vector3(i - 1, spectrum[i] + 10, 0), new Vector3(i, spectrum[i + 1] + 10, 0), Color.red);
        //    Debug.DrawLine(new Vector3(i - 1, Mathf.Log(spectrum[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(spectrum[i]) + 10, 2), Color.cyan);
        //    Debug.DrawLine(new Vector3(Mathf.Log(i - 1), spectrum[i - 1] - 10, 1), new Vector3(Mathf.Log(i), spectrum[i] - 10, 1), Color.green);
        //    Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(spectrum[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(spectrum[i]), 3), Color.blue);
        //}
    }


    public float[] getSpectrum()
    {
        return spectrum;
    }

    public float getFrequency(int index)
    {
        if (index >= binCount)
        {
            Debug.LogError($"Getting a bin at {index} which is outside range");
            return 0;
        }

        return spectrum[index];
    }
}
