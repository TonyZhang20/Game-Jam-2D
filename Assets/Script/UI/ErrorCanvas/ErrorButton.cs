using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Script.UI.ErrorCanvas
{
    public class ErrorButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Sprite error;
        public Sprite unSelectError;
        public Image image;
        public GameObject errorCanvas;

        public void OnPointerClick(PointerEventData eventData)
        {
            errorCanvas.gameObject.SetActive(false);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            image.sprite = unSelectError;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            image.sprite = error;
        }
    }
}
