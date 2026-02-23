using System;
using UnityEngine;
public class ScaleListener : ListenerScript
{
    public float xScale = 1, yScale = 1, zScale = 1;

    void Update()
    {
        float value = GetLevel();

        transform.localScale = new Vector3(xScale * value, yScale * value, zScale * value);
    }
}
