using System;
using System.Collections;
using System.Collections.Generic;
using Script.UI.DialogueSystem;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

namespace Script.UI.ChatCanvas
{
    public class ChatCanvasController : MonoBehaviour
    {
        public static ChatCanvasController Instance => _instance;
        private static ChatCanvasController _instance;
        public List<RectTransform> initPosition;
        public List<Color> colors;
        public GameObject tempText;
        
        [Header("弹幕同频最大数量")] public int chatMaxNum = 3;
        [SerializeField] public DialogueSO dialogueSo;

        private Coroutine _chatCoroutine;
        private void Awake()
        {
            Singleton();
        }
        
        private void Start()
        {
            ShowChat(dialogueSo);
        }

        private void Singleton()
        {
            if (_instance == null) _instance = this;
            else Destroy(gameObject);
        }
        
        private IEnumerator WorkChat()
        {
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < 3; i++)
            {
                ShowChat("我真的受不了这个主题了，走了的了");
                yield return new WaitForSeconds(2f);
            }
        }

        private RectTransform GetRandomPosition()
        {
            int index = Random.Range(0, initPosition.Count);
            return initPosition[index];
        }

        public void ShowChat(DialogueSO dialogueSo)
        {
            if (_chatCoroutine != null)
            {
                StopCoroutine(_chatCoroutine);
                _chatCoroutine = null;
            }
            _chatCoroutine = StartCoroutine(PlayChat(dialogueSo));
        }

        private IEnumerator PlayChat(DialogueSO dialogueSo)
        {
            while (FindObjectsOfType<ChatMove>().Length < chatMaxNum)
            {
                ShowChat(dialogueSo.GetRandomDialogue());
                yield return new WaitForSeconds(1.8f);
            }

            yield return new WaitForSeconds(0.2f);
            
            _chatCoroutine = null;
            ShowChat(dialogueSo);
        }
        

        /// <summary>
        /// 用模板字体样式生成弹幕
        /// </summary>
        /// <param name="content"></param>
        public void ShowChat(string content)
        {
            var rect = GetRandomPosition();
            var game = Instantiate(tempText,transform);
            game.transform.position = rect.position;
            
            game.GetComponent<TextMeshProUGUI>().text = content;
            game.GetComponent<TextMeshProUGUI>().fontSize = Random.Range(50, 72);
            game.GetComponent<TextMeshProUGUI>().color = colors[Random.Range(0, colors.Count)];
            game.AddComponent<ChatMove>();
        }

        /// <summary>
        /// 用指定的字体样式生成弹幕
        /// </summary>
        /// <param name="content"></param>
        /// <param name="target"></param>
        public void ShowChat(string content, GameObject target)
        {
            var rect = GetRandomPosition();
            var game = Instantiate(target,transform);
            game.transform.position = rect.position;
            
            game.GetComponent<TextMeshProUGUI>().text = content;
            game.AddComponent<ChatMove>();
        }
    }
}
