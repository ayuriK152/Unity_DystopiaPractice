using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_DialogueLine : MonoBehaviour
{

    public Define.DialogueSubject _dialSub;
    public TextMeshProUGUI _text;
    public string _textData;
    private int _textLen;

    private void Awake()
    {
        Init();
    }

    public void ShowLetters()     //TODO: 한 글자씩 업데이트
    {
        _textLen = _textData.Length;
        StartCoroutine("UpdateDialogueLetter");
        return;
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

    IEnumerator UpdateDialogueLetter ()
    {
        for (int i = 0; i < _textLen; i++)
        {
            _text.text = _textData.Substring(0, i);
            yield return new WaitForSeconds(0.02f);
        }
    }
}
