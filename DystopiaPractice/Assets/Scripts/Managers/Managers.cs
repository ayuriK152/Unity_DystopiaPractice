using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers _manager = new Managers();
    public static Managers Manager { get { Init(); return _manager; } }

    #region Core
    static InputManager _inputManager = new InputManager();
    public static InputManager Input { get { Init(); return _inputManager; } }
    #endregion

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        Input.OnUpdate();
    }

    private static void Init()
    {
        if (_manager == null)
        {
            GameObject go = GameObject.Find("@Manager");

            DontDestroyOnLoad(go);
            _manager = go.GetComponent<Managers>();
        }
    }
}
