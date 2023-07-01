using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Script.UI.DialogueSystem
{
    public class DialogueCanvas : MonoBehaviour
    {
        public static DialogueCanvas Instance => _instance;
        private static DialogueCanvas _instance;
        
        [SerializeField] public TextMeshProUGUI text;
        [SerializeField, Range(0,1),Header("每个字间隔长短")] public float spaceBetweenWords = 0.2f;
        [SerializeField, Range(0, 5), Header("每句话结束后等待时间")]
        public float spaceBetweenSentence = 2f;

     

        private bool _duringDialogue;
        
        private void Awake()
        {
            Singleton();
            text.text = string.Empty;
            text.gameObject.SetActive(false);
        }

        private void Singleton()
        {
            if (_instance == null) _instance = this;
            else Destroy(gameObject);
        }

        
        public void CallDialogue(DialogueSO dialogueSo)
        {
            StartCoroutine(DoDialogue(dialogueSo));
        }

        public void CallDialogue(string content)
        {
            text.gameObject.SetActive(true);
            text.text = string.Empty;
            StartCoroutine(DoDialogue(content));
        }

        private IEnumerator DoDialogue(DialogueSO dialogueSo)
        {
            _duringDialogue = true;
            foreach (var s in dialogueSo.dialogueList)
            {
                CallDialogue(s);
                yield return new WaitUntil((() => _duringDialogue == false));
            }
        }

        private IEnumerator DoDialogue(string content)
        {
            _duringDialogue = true;
            
            foreach (var s in content)
            {
                text.text += s;
                yield return new WaitForSeconds(spaceBetweenSentence);
            }

            yield return new WaitForSeconds(2);
            text.gameObject.SetActive(false);

            _duringDialogue = false;
        }
    }
}
