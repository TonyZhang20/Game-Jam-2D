using System;
using Script.UI.ChatCanvas;
using Script.UI.DialogueSystem;
using UnityEngine;

namespace Script.EventTrigger
{
    public class ShowChatOne : MonoBehaviour
    {
        public DialogueSO dialogue;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                ChatCanvasController.Instance.ShowChat(dialogue);
            }
        }
    }
}
