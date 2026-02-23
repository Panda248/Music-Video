using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PositionListener : ListenerScript
{
    public float xMult = 1, yMult = 1, zMult = 1, xFreq = 1, yFreq = 1, zFreq = 1;
    private float t;
    Vector3 origin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();
        t = Random.Range(0, Mathf.PI);
        origin = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float lvl = GetLevel();
        t += Time.deltaTime * lvl;

        Vector3 newPos = origin + new Vector3(xMult * Mathf.Cos(t * xFreq),
                                              yMult *  Mathf.Sin(t * yFreq),
                                              zMult * Mathf.Cos(t * zFreq));

        transform.localPosition = newPos;
    }
}
