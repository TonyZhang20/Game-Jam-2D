using UnityEngine;

namespace Script
{
    public class ParallaxBackground : MonoBehaviour
    {
        public float offsetFactor = 0.1f; // 偏移系数

        private Transform _cameraTransform;
        private Vector3 _lastCameraPosition;

        [SerializeField] private Camera _camera;

        private void Start()
        {
            _cameraTransform = _camera.transform;
            _lastCameraPosition = _cameraTransform.position;
        }

        private void LateUpdate()
        {
            // 获取相机的当前位置
            Vector3 cameraPosition = _cameraTransform.position;

            // 计算相机移动的距离
            Vector3 cameraDelta = cameraPosition - _lastCameraPosition;

            // 根据偏移系数调整背景图的移动量
            Vector3 offset = offsetFactor * cameraDelta;

            // 更新背景图的位置
            transform.position += new Vector3(offset.x, offset.y, 0);

            // 更新相机位置
            _lastCameraPosition = cameraPosition;
        }
    }
}