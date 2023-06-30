using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.UI
{
    public class MenuCanvas : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            Time.timeScale = 0;
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
        }

        /// <summary>
        /// 关闭Menu
        /// </summary>
        public void Continue()
        {
            gameObject.SetActive(false);
        }
        
        /// <summary>
        /// 回到菜单
        /// </summary>
        public void BackToMenu()
        {
            SceneManager.LoadScene(0);
        }


    }
}
