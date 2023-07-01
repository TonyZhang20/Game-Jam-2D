using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI.HealthBarController
{
    public class HealthBar : MonoBehaviour
    {
        public List<Image> images;
        public Sprite fullHeart;
        public Sprite halfWhiteHeart;
        public Sprite whiteHeart;
        public Sprite emptyHeart;

        private void Start()
        {
        }

        private void Update()
        {
        
        }

        public void UpDateHealthBar(int health)
        {
            for (int i = 0; i < health; i++)
            {
                images[i].sprite = fullHeart;
            }

            for (int i = health; i < 3; i++)
            {
                images[i].sprite = emptyHeart;
            }
        }
    }
}
