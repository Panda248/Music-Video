using UnityEngine;

public class SectionScript : MonoBehaviour
{
    public Material skyboxMaterial;
    public bool writeLight = false, writeGirl = false;
    public Color lightColor, girlColor;

    void OnEnable()
    {
        Skybox skybox = FindAnyObjectByType<Skybox>();
        skybox.material = skyboxMaterial;
        Light light = GameObject.FindWithTag("MainLight").GetComponent<Light>();
        Light girl = GameObject.FindWithTag("GirlLight").GetComponent<Light>();
        if(writeLight) light.color = lightColor;
        if(writeGirl) girl.color = girlColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
