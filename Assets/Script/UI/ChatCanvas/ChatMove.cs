using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Script.UI.ChatCanvas
{
    public class ChatMove : MonoBehaviour
    {
        public Vector2 moveRandomRange = new Vector2(160, 240);
        public float moveSpeed = 180f;
        public float aliveTime = 12f;

        private void OnEnable()
        {
            Invoke(nameof(DestroyItSelf),aliveTime);
        }

        private void DestroyItSelf()
        {
            Destroy(gameObject);
        }

        private void Update()
        {
            moveSpeed = Random.Range(moveRandomRange.x, moveRandomRange.y);
            transform.position += (Vector3.left * moveSpeed * Time.deltaTime);
        }
    }
    
}
