using System;
using System.Collections;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

namespace Script.CameraZoom
{
    public class ZoomCameraFirst : MonoBehaviour
    {
        public GameObject side;
        public Vector3 targetZoom;
        public Vector3 originZoom;
        public float zoomTime;
        public CinemachineVirtualCamera mCamera;
        

        private void ZoomIn()
        {
            side.transform.DOScale(originZoom, zoomTime);
            StartCoroutine(ChangeCameraZoom());
        }

        private IEnumerator ChangeCameraZoom()
        {
            while (mCamera.m_Lens.OrthographicSize < 6)
            {
                mCamera.m_Lens.OrthographicSize += Time.deltaTime;
                yield return null;
            }
            
            Destroy(gameObject);
        }

        public void ZoomOut()
        {
            side.transform.DOScale(targetZoom, zoomTime);
            mCamera.m_Lens.OrthographicSize = 5;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            ZoomIn();
        }
    }
}
