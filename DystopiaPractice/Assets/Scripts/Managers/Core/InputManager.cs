using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;

    public void OnUpdate()
    {
        if (Input.anyKeyDown && KeyAction != null)
        {
            KeyAction.Invoke();
        }
    }

    public void Clear()
    {
        KeyAction = null;
    }
}
