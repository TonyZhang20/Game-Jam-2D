using System;
using Script.PlayerControl;
using UnityEngine;

namespace Script
{
    public class Enemy : MonoBehaviour
    {


        private bool _forwadHasWay;
        private bool _downHasWay;
        [SerializeField,Header("移动速度")] private float speed = 3;
        [SerializeField] private LayerMask _layerMask;
        private Vector2 _moveDirection = new Vector2(1,0);
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            
        }

        private void Update()
        {
            PathFinder();
            _moveDirection.y = -9.8f;
            _rigidbody2D.velocity = _moveDirection * speed;
            
            
        }
        
        private void PathFinder()
        {
            RaycastHit2D forwardHit = Physics2D.Raycast(transform.position, Vector2.right, 0.7f, _layerMask);
            RaycastHit2D backwardHit = Physics2D.Raycast(transform.position, -Vector2.right, 0.7f, _layerMask);
            
            RaycastHit2D downWardRight = Physics2D.Raycast(transform.position, Vector2.down, 2f, _layerMask);


            if (forwardHit) _moveDirection.x = -1;
            if (backwardHit) _moveDirection.x = 1;
            if (!downWardRight) _moveDirection.x *= -1;

            if (_moveDirection.x > 0) _spriteRenderer.flipX = true;
            else if (_moveDirection.x < 0) _spriteRenderer.flipX = false;
        }
        
        

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.CompareTag("Player"))
            {
                other.transform.GetComponent<PlayerController>().GetHit();
                _moveDirection *= -1;
            }
        }

        public void GetHit()
        {
            Destroy(gameObject);
        }

    }
}
