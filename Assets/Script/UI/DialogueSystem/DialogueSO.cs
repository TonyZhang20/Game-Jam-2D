using System.Collections.Generic;
using UnityEngine;

namespace Script.UI.DialogueSystem
{
    [CreateAssetMenu(fileName = "对话文本1", menuName = "对话文本/Dialogue_SO", order = 0)]
    public class DialogueSO : ScriptableObject
    {
        [TextArea]
        public List<string> dialogueList;
    }
}