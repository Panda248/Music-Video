using Unity.VisualScripting;
using UnityEngine;

public class CubeVisualizer : MonoBehaviour
{
    public AudioSpectrum spectrumScript;
    public float cubeDist = 1.01f; // distance between the center of each cube
    public float cubeSize = 1f;
    public float scale = 1.0f;
    private int cubeCount; // determined by the AudioSpectrum Component
    //private int cubeCutoff;
    GameObject[] cubes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cubeCount = spectrumScript.binCount;
        cubes = new GameObject[cubeCount];
        float width = (cubeCount - 1) * cubeDist;
        float offset = transform.position.x - (width / 2);

        for (int i = 0; i < cubeCount; i++)
        {
            cubes[i] = new GameObject($"{i}");
            GameObject cubePrimitive = GameObject.CreatePrimitive(PrimitiveType.Cube);

            cubes[i].transform.parent = transform;
            cubePrimitive.transform.parent = cubes[i].transform;
            cubePrimitive.transform.localPosition = new Vector3(0f, 0.5f, 0f);
            cubePrimitive.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

            cubes[i].transform.localPosition = new Vector3(offset + (i * cubeDist), 0f, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float[] spectrumData = spectrumScript.getSpectrum();

        for(int i = 0; i < cubeCount; i++)
        {
            cubes[i].transform.localScale = new Vector3(1, spectrumData[i] * scale, 1);
        }
    }
}
