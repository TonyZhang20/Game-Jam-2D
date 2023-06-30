using System;
using UnityEngine;


namespace Script.PlayerControl
{
    public class PlayerController : MonoBehaviour
    {
        public InputSignal inputSignal;
        [SerializeField, Range(0, 100f)] private float maxSpeed = 4f;
        [SerializeField, Range(0, 100f)] private float maxAcceleration = 35f;
        [SerializeField, Range(0, 100f)] private float maxAirAcceleration = 20f;

        private Vector2 _direction;
        private Vector2 _desiredVelocity;
        private Vector2 _velocity;
        private Rigidbody2D _body;
        private Ground _ground;

        private float _maxSpeedChange;
        private float _acceleration;
        private bool _onGround;
        
        private void Start()
        {
            _body = GetComponent<Rigidbody2D>();
            _ground = GetComponent<Ground>();
            
        }

       

        private void Update()
        {
            ReceiveInputSignal();
        }

        private void FixedUpdate()
        {
            _onGround = _ground.GetOnGround();
            _velocity = _body.velocity;

            _acceleration = _onGround ? maxAcceleration : maxAirAcceleration;
            _maxSpeedChange = _acceleration * Time.deltaTime;
            _velocity.x = Mathf.MoveTowards(_velocity.x, _desiredVelocity.x, _maxSpeedChange);

            _body.velocity = _velocity;
        }

        private void ReceiveInputSignal()
        {

            if (Input.GetKey(inputSignal.leftSide))
            {
                //moveLeft
                _direction.x = -1;
            }
            if (Input.GetKey(inputSignal.rightSide))
            {
                //moveRight
                _direction.x = 1;
            }

            if (Input.GetKey(inputSignal.leftSide) && Input.GetKey(inputSignal.rightSide))
            {
                _direction.x = 0;
            }
            else if (!Input.GetKey(inputSignal.leftSide) && !Input.GetKey(inputSignal.rightSide))
            {
                _direction.x = 0;
            }




            _desiredVelocity = new Vector2(_direction.x, 0f) * Mathf.Max(maxSpeed - _ground.GetFriction(),0); 
            
            if (Input.GetKeyDown(inputSignal.jump))
            {
                //跳
            }
        }
    }
    [System.Serializable]
    public class InputSignal
    {
        [Header("左")] public KeyCode leftSide;
        [Header("右")] public KeyCode rightSide;
        [Header("跳")] public KeyCode jump;
    }
}
