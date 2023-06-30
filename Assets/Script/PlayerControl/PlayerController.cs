using System;
using UnityEngine;

namespace Script.PlayerControl
{
    public abstract class PlayerController : MonoBehaviour
    {
        [Header("前进")] public KeyCode forward;
        [Header("后退")] public KeyCode backward;
        [Header("左移")] public KeyCode leftSide;
        [Header("右移")] public KeyCode rightSide;

        public abstract void MoveForward();

        public abstract void MoveBackward();

        public abstract void MoveLeft();

        public abstract void MoveRight();

        protected virtual void PlayerUpdate()
        {
            
        }

        private void Update()
        {
            PlayerUpdate();
        }
        
        
    }
}
