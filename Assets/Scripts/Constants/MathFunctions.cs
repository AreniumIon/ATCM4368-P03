using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class MathFunctions
{
    // Helpers
    public static float Clamp(float value, float minValue = float.MinValue, float maxValue = float.MaxValue)
    {
        return Mathf.Clamp(value, minValue, maxValue);
    }

    public static int Clamp(int value, int minValue = int.MinValue, int maxValue = int.MaxValue)
    {
        return Mathf.Clamp(value, minValue, maxValue);
    }

    public static float Lerp(float a, float b, float t)
    {
        return a * (1 - t) + b * t;
    }

    // Referenced
    public static IEnumerator FadeImage(Image image, float startAlpha, float targetAlpha, float time)
    {
        if (targetAlpha != 0)
            image.gameObject.SetActive(true);

        float timer = 0;

        while (image.color.a != targetAlpha)
        {
            yield return null;
            timer += Time.deltaTime;

            // Calculate alpha
            float a = Mathf.Lerp(startAlpha, targetAlpha, Mathf.Clamp(timer / time, 0, 1));

            // Apply alpha
            Color newColor = image.color;
            newColor.a = a;
            image.color = newColor;
        }

        // Set object inactive if alpha is 0
        if (targetAlpha == 0)
            image.gameObject.SetActive(false);
    }

    public static IEnumerator MoveTo(Transform transform, Vector2 targetPos, float time)
    {
        Vector2 startPos = transform.position;

        float timer = 0;

        while ((Vector2) transform.position != targetPos)
        {
            yield return null;
            timer += Time.deltaTime;

            // Calculate
            float t = Clamp(timer / time, 0, 1);
            float x = Lerp(startPos.x, targetPos.x, t);
            float y = Lerp(startPos.y, targetPos.y, t);

            // Apply
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }

    public static IEnumerator MoveToKick(Transform transform, Vector2 targetPos, float speed)
    {
        Vector2 startPos = transform.position;

        float timer = 0;

        while ((Vector2)transform.position != targetPos)
        {
            yield return null;
            timer += Time.deltaTime;

            // Calculate
            float t = Clamp(KickAccelerate(timer * speed), -1, 1);
            float x = Lerp(startPos.x, targetPos.x, t);
            float y = Lerp(startPos.y, targetPos.y, t);

            // Apply
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }

    // Input: (0, 1) Output: (-.2, 1)
    private static float KICK_AMOUNT = .1f;
    private static float KICK_TIME = .3f;
    public static float KickAccelerate(float t)
    {
        float a = KICK_AMOUNT / (KICK_TIME * KICK_TIME);
        return a * (t - KICK_TIME) * (t - KICK_TIME) - KICK_AMOUNT;
    }
}
