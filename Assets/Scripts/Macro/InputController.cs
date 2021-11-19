using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
    public void InvokeConfirm() { PressedConfirm?.Invoke(); }
    public event Action PressedConfirm = delegate { };

    public void InvokeCancel() { PressedCancel?.Invoke(); }
    public event Action PressedCancel = delegate { };

    public void InvokeLeft() { PressedLeft?.Invoke(); }
    public event Action PressedLeft = delegate { };

    public void InvokeRight() { PressedRight?.Invoke(); }
    public event Action PressedRight = delegate { };

    private void Update()
    {
        DetectConfirm();
        DetectCancel();
        DetectLeft();
        DetectRight();
    }

    private void DetectConfirm()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeConfirm();
        }
    }

    private void DetectCancel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InvokeCancel();
        }
    }

    private void DetectLeft()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            InvokeLeft();
        }
    }

    private void DetectRight()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            InvokeRight();
        }
    }
}
