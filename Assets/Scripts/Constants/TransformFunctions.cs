using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformFunctions
{
    // Used by constructors
    public static Transform SetTransform(Transform receiver, Transform setter)
    {
        if (setter != null)
        {
            receiver.position = setter.position;
            receiver.rotation = setter.rotation;
            receiver.localScale = setter.localScale;
        }
        return receiver;
    }
    public static Transform SetTransform(Transform receiver, Vector3? position)
    {
        if (position != null) receiver.position = (Vector3)position;
        return receiver;
    }
    public static Transform SetTransform(Transform receiver, Vector3? position, Quaternion? rotation, Vector3? localScale)
    {
        if (position != null) receiver.position = (Vector3)position;
        if (rotation != null) receiver.rotation = (Quaternion)rotation;
        if (localScale != null) receiver.localScale = (Vector3)localScale;
        return receiver;
    }
    public static Transform SetTransform(Transform receiver, Vector3? position, Vector3? eulerAngles, Vector3? localScale)
    {
        if (position != null) receiver.position = (Vector3)position;
        if (eulerAngles != null) receiver.eulerAngles = (Vector3)eulerAngles;
        if (localScale != null) receiver.localScale = (Vector3)localScale;
        return receiver;
    }
}
