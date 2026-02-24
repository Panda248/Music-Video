using UnityEngine;

public class SectionScript : MonoBehaviour
{
    public Material skyboxMaterial;
    public bool writeLight = false, writeGirl = false;
    public Color lightColor, girlColor;
    public float lightIntensity, girlIntensity;

    public virtual void OnEnable()
    {
        Skybox skybox = FindAnyObjectByType<Skybox>();
        Camera camm = FindAnyObjectByType<Camera>();
        camm.clearFlags = CameraClearFlags.Skybox;
        skybox.material = skyboxMaterial;
        Light light = GameObject.FindWithTag("MainLight").GetComponent<Light>();
        Light girl = GameObject.FindWithTag("GirlLight").GetComponent<Light>();
        if (writeLight)
        {
            light.color = lightColor;
            light.intensity = lightIntensity;
        }
        if (writeGirl)
        {
            girl.intensity = girlIntensity;
            girl.color = girlColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
