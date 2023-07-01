using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.UI.CameraOverLapUI
{
    public class PauseButton : MonoBehaviour,IPointerClickHandler
    {
        public Image pauseButton;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseButton.color = new Color(pauseButton.color.r, pauseButton.color.g, pauseButton.color.b, 0);
            }
            else
            {
                Time.timeScale = 1;
                pauseButton.color = new Color(pauseButton.color.r, pauseButton.color.g, pauseButton.color.b, 1);
            }
        }
    }
}
