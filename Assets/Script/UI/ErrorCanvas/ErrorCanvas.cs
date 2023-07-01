using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI.ErrorCanvas
{
    public class ErrorCanvas : MonoBehaviour
    {
        public List<Image> errorList = new List<Image>();

        private void OnEnable()
        {
            ShowError();
            Time.timeScale = 0;
            GameManager.AbleToInput = false;
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
            GameManager.AbleToInput = true;
        }

        public void ShowError()
        {
            StartCoroutine(ShowErrorsBySecond());
        }

        private IEnumerator ShowErrorsBySecond()
        {
            foreach (var error in errorList)
            {
                error.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.4f);
            }
            
        }
    }
}
