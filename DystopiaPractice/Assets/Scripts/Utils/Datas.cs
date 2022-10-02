using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datas
{
    [System.Serializable]
    public class DialogueLineData
    {
        private static int index = 0;
        public Define.DialogueSubject _dialogueSubject;
        public String _text;

        public DialogueLineData()
        {
            index++;
        }
    }
}