using System;
using UnityEngine;

namespace Script.PlayerControl
{
    public class Jump : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float jumpHeight = 3f;
        [SerializeField, Range(0, 5)] private int maxAirJumps = 1;
        [SerializeField, Range(0, 5)] private float downwardMovementMultiplier = 3;
        [SerializeField, Range(0, 5)] private float upwardMovementMultiplier = 1.7f;
        private PlayerController _playerController;

        private Rigidbody2D _body;
        private Ground _ground;
        private Vector2 _velocity;

        private int _jumpPhase;
        private float _defaultGravityScale;

        private bool _desiredJump;
        private bool _onGround;
        
        private void Start()
        {
            _playerController = GetComponent<PlayerController>();
            _body = GetComponent<Rigidbody2D>();
            _ground = GetComponent<Ground>();

            _defaultGravityScale = 1f;
        }

        private void Update()
        {
            _desiredJump = Input.GetKeyDown(_playerController.inputSignal.jump);
            
            _onGround = _ground.GetOnGround();
            _velocity = _body.velocity;
            if (_onGround) _jumpPhase = 0;
            if (_desiredJump) JumpAction();

            if (_body.velocity.y > 0)
                _body.gravityScale = upwardMovementMultiplier;
            else if (_body.velocity.y < 0)
                _body.gravityScale = downwardMovementMultiplier;
            else
                _body.gravityScale = _defaultGravityScale;

            _body.velocity = _velocity;
        }

        private void FixedUpdate()
        {

        }

        private void JumpAction()
        {
            if (_onGround || _jumpPhase < maxAirJumps)
            {
                _jumpPhase += 1;
                float jumpSpeed = Mathf.Sqrt(-2f * Physics2D.gravity.y * jumpHeight);
                if (_velocity.y > 0)
                {
                    jumpSpeed = Mathf.Max(jumpSpeed - _velocity.y, 0);
                }
                _velocity.y += jumpSpeed;
            }
        }
    }
}
