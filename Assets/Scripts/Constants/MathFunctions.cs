using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathFunctions
{
    public static float Clamp(float value, float minValue = float.MinValue, float maxValue = float.MaxValue)
    {
        return Mathf.Clamp(value, minValue, maxValue);
    }

    public static int Clamp(int value, int minValue = int.MinValue, int maxValue = int.MaxValue)
    {
        return Mathf.Clamp(value, minValue, maxValue);
    }
}
