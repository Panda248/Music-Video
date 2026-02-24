using UnityEngine;

public class Section5Script : SectionScript
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void OnEnable()
    {
        base.OnEnable();
        Camera camm = FindAnyObjectByType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
