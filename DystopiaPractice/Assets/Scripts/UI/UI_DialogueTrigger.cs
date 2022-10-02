using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    public Datas.DialogueLineData[] _dialogueDatas;

    public void TriggerDialogue()
    {
        Managers.Dialogue._dialogueTrigger = gameObject;
        Managers.Dialogue.StartDialogue();
    }
}