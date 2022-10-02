using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputTest : MonoBehaviour
{
    private void Start()
    {
        Managers.Input.KeyAction -= OnUpdateTest;
        Managers.Input.KeyAction += OnUpdateTest;
    }

    public void OnUpdateTest()
    {
        Debug.Log("Input worked succesfully");
    }
}