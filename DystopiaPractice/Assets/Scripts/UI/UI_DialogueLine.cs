using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_DialogueLine : MonoBehaviour
{

    public Define.DialogueSubject _dialSub;
    public TextMeshProUGUI _text;

    private void Awake()
    {
        Init();
        _text.text = " ";
    }

    private void Init()
    {
        if (gameObject.name == "PlayerTextBox")
            _dialSub = Define.DialogueSubject.Player;
        else if (gameObject.name == "OpponentTextBox")
            _dialSub = Define.DialogueSubject.Opponent;
        else
            _dialSub = Define.DialogueSubject.Unknown;

        _text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }
}
