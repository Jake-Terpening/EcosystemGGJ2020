using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleController : MonoBehaviour
{
    public float cycleDuration;
    public static bool cycleActive;

    private float cycleStartTime;

    private void Update()
    {
        if ((Time.time - cycleStartTime) < cycleDuration)
            cycleActive = true;
        else
            cycleActive = false;
    }

    public void StartCycle()
    {
        cycleStartTime = Time.time;
    }
}
