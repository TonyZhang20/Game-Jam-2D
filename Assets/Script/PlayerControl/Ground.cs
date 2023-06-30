using System;
using UnityEngine;

namespace Script.PlayerControl
{
    public class Ground : MonoBehaviour
    {
        private bool _onGround;
        private float _friction;

        private void OnCollisionEnter2D(Collision2D other)
        {
            EvaluateCollision(other);
            RetrieveFriction(other);
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            EvaluateCollision(other);
            RetrieveFriction(other);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            _onGround = false;
            _friction = 0;
        }

        private void EvaluateCollision(Collision2D collision)
        {
            for (int i = 0; i < collision.contactCount; i++)
            {
                Vector2 normal = collision.GetContact(i).normal;
                _onGround |= normal.y > 0.9f;
            }
        }

        private void RetrieveFriction(Collision2D collision)
        {
            PhysicsMaterial2D material = collision.rigidbody.sharedMaterial;

            _friction = 0;
            if (material != null)
                _friction = material.friction;
        }

        public bool GetOnGround()
        {
            return _onGround;
        }

        public float GetFriction()
        {
            return _friction;
        }
    }
}
