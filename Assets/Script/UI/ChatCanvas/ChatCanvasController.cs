using System;
using System.Collections;
using System.Collections.Generic;
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
        public GameObject tempText;
        private void Awake()
        {
            Singleton();
        }

        private void Singleton()
        {
            if (_instance == null) _instance = this;
            else Destroy(gameObject);
        }

        private void Start()
        {
            StartCoroutine(WorkChat());
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
