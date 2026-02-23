using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PositionListener : ListenerScript
{
    public float xMult, yMult, zMult, xFreq, yFreq, zFreq;
    private float t;
    Vector3 origin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        t = 0;
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float lvl = GetLevel();
        t += Time.deltaTime * lvl;
        if(t > Mathf.PI * 2)
        {
            t -= Mathf.PI * 2;
        }

        Vector3 newPos = origin + new Vector3(xMult * Mathf.Cos(t * xFreq),
                                              yMult *  Mathf.Sin(t * yFreq),
                                              zMult * Mathf.Cos(t * zFreq));

        transform.position = newPos;
    }
}
