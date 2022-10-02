using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    static Managers _manager = new Managers();
    public static Managers Manager { get { Init(); return _manager; } }

    #region Core
    static InputManager _inputManager = new InputManager();
    static DialogueManager _dialogueManager = new DialogueManager();
    public static InputManager Input { get { return _inputManager; } }
    public static DialogueManager Dialogue { get { return _dialogueManager; } }
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

        Dialogue.Init();
    }
}