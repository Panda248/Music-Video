using UnityEngine;

public class LightVisualizer : MonoBehaviour
{
    public AudioSpectrum spectrumScript;
    public float lightDist = 1.01f; // distance between the center of each cube
    public float lightFloor = 1f;
    public float scale = 1.0f;
    private int lightCount; // determined by the AudioSpectrum Component

    private GameObject[] lights;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightCount = spectrumScript.binCount;
        lights = new GameObject[lightCount];

        float width = (lightCount - 1) * lightDist;
        float offset = transform.position.x - (width / 2);

        for (int i = 0; i < lightCount; i++)
        {
            lights[i] = new GameObject($"{i}");
            lights[i].AddComponent<Light>();
            Light light = lights[i].GetComponent<Light>();
            light.type = LightType.Point;
            light.range = 100f;

            lights[i].transform.parent = transform;
            lights[i].transform.localPosition = new Vector3(offset + (i * lightDist), 0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float[] spectrumData = spectrumScript.getSpectrum();

        for (int i = 0; i < lightCount; i++)
        {
            lights[i].GetComponent<Light>().intensity = lightFloor + (spectrumData[i] * scale);
        }
    }
}
