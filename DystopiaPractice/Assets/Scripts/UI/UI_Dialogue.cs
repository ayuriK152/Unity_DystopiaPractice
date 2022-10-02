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

    [SerializeField]
    public Datas.DialogueLineData[] _dialogueLinesDatas;

    Dictionary<int, Datas.DialogueLineData> _dialogueDict = new Dictionary<int, Datas.DialogueLineData>();

    private void Start()
    {
        _dialogueLinePlayer = Resources.Load<GameObject>("Prefabs/UI/PlayerTextBox");
        _dialogueLineOpponent = Resources.Load<GameObject>("Prefabs/UI/OpponentTextBox");
        _dialogueScrollContainer = GameObject.Find("Dialogues");

        for (int i = 0; i < _dialogueLinesDatas.Length; i++)
            _dialogueDict.Add(i, _dialogueLinesDatas[i]);

        StartCoroutine("ScrollUpdate");
    }

    void CreateDialogue(int idx)
    {
        Datas.DialogueLineData dl;
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
        foreach(Datas.DialogueLineData line in _dialogueDict.Values)
        {
            CreateDialogue(idx);
            yield return new WaitForSeconds(2.0f);
            idx++;
            if (idx != _dialogueDict.Count && _dialogueDict.Count != 1)
                _dialogueScrollContainer.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, 32);
        }

        Destroy(gameObject);
    }
}