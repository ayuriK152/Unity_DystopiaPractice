using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Dialogue : MonoBehaviour
{
    GameObject _dialogueLinePlayer;
    GameObject _dialogueLineOpponent;
    GameObject _dialogueScrollContainer;

    DialogueLineData _dialogueLinesData;
    DialogueLineData[] _dialogueLinesDatas;

    Dictionary<int, DialogueLineData> _dialogueDict = new Dictionary<int, DialogueLineData>();

    void TestCode()
    {
        _dialogueLinesDatas = new DialogueLineData[5];
        for (int i = 0; i < 5; i++)
        {
            _dialogueLinesDatas[i] = new DialogueLineData();
            _dialogueLinesDatas[i].index = i;
        }

        _dialogueLinesDatas[0]._dialogueSubject = Define.DialogueSubject.Player;
        _dialogueLinesDatas[1]._dialogueSubject = Define.DialogueSubject.Opponent;
        _dialogueLinesDatas[2]._dialogueSubject = Define.DialogueSubject.Player;
        _dialogueLinesDatas[3]._dialogueSubject = Define.DialogueSubject.Opponent;
        _dialogueLinesDatas[4]._dialogueSubject = Define.DialogueSubject.Player;

        _dialogueLinesDatas[0]._text = "Hello there!";
        _dialogueLinesDatas[1]._text = "Oh, hi!";
        _dialogueLinesDatas[2]._text = "How's going?";
        _dialogueLinesDatas[3]._text = "Just Not Bad.";
        _dialogueLinesDatas[4]._text = "Well,";

        _dialogueLinesData = new DialogueLineData();
        _dialogueLinesData.index = 5;
        _dialogueLinesData._dialogueSubject = Define.DialogueSubject.Player;
        _dialogueLinesData._text = "hope you fine.";
    }

    private void Awake()
    {
        _dialogueLinePlayer = Resources.Load<GameObject>("Prefabs/UI/PlayerTextBox");
        _dialogueLineOpponent = Resources.Load<GameObject>("Prefabs/UI/OpponentTextBox");
        _dialogueScrollContainer = GameObject.Find("DialogueBoxes");

        TestCode();

        for (int i = 0; i < 5; i++)
            _dialogueDict.Add(i, _dialogueLinesDatas[i]);
        _dialogueDict.Add(5, _dialogueLinesData);

        StartCoroutine("ScrollUpdate");
    }

    class DialogueLineData
    {
        public int index;
        public Define.DialogueSubject _dialogueSubject;
        public String _text;
    }

    void CreateDialogue(int idx)
    {
        DialogueLineData dl;
        GameObject go = null;
        _dialogueDict.TryGetValue(idx, out dl);

        switch (dl._dialogueSubject)
        {
            case Define.DialogueSubject.Player:
                go = Instantiate(_dialogueLinePlayer);
                break;
            case Define.DialogueSubject.Opponent:
                go = Instantiate(_dialogueLineOpponent);
                break;
        }

        if (go != null)
        {
            go.GetComponent<UI_DialogueLine>()._textData = dl._text;
            go.transform.parent = transform;
            go.GetComponent<UI_DialogueLine>().ShowLetters();
            go.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            go.transform.parent = _dialogueScrollContainer.transform;
        }
    }

    IEnumerator ScrollUpdate()
    {
        int idx = 0;
        foreach(DialogueLineData line in _dialogueDict.Values)
        {
            CreateDialogue(idx);
            yield return new WaitForSeconds(2.0f);
            idx++;
            if (idx != _dialogueDict.Count && _dialogueDict.Count != 1)
                _dialogueScrollContainer.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 32);
        }
    }
}
