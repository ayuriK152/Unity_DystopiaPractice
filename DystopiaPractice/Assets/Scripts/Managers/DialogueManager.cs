using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    GameObject _dialogueBox;
    GameObject temp;
    public GameObject _dialogueTrigger = null;

    public void Init()
    {
        _dialogueBox = Resources.Load<GameObject>("Prefabs/UI/DialogueBox");
    }

    // TODO: NPC 이미지 출력, 선택지 생성 및 분기
    public void StartDialogue()
    {
        if (temp != null)
            temp = null;

        temp = Instantiate(_dialogueBox);
        temp.transform.SetParent(GameObject.Find("DialoguePanel").transform);
        temp.transform.localPosition = Vector2.zero;
        temp.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        temp.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
        temp.GetComponent<UI_Dialogue>()._dialogueLinesDatas = _dialogueTrigger.GetComponent<UI_DialogueTrigger>()._dialogueDatas;
        temp.SetActive(true);
    }
}