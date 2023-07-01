using System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Script.PlayerControl
{
    public class PlayerController : MonoBehaviour
    {
        public InputSignal inputSignal;
        public Vector2 direction;
        [SerializeField, Range(0, 100f)] private float maxSpeed = 4f;
        [SerializeField, Range(0, 100f)] private float maxAcceleration = 35f;
        [SerializeField, Range(0, 100f)] private float maxAirAcceleration = 20f;

        public int currentHealth = 3;
        public int maxHealth = 3;

        private Vector2 _direction;
        private Vector2 _desiredVelocity;
        private Vector2 _velocity;
        private Rigidbody2D _body;
        private Ground _ground;

        private float _maxSpeedChange;
        private float _acceleration;
        private bool _onGround;

        private Vector3 _lastFromPosition;
        [SerializeField] private LayerMask layerMask;
        private void Start()
        {
            _body = GetComponent<Rigidbody2D>();
            _ground = GetComponent<Ground>();
            direction = new Vector2(1, 1);
        }

        private void Update()
        {
            if(GameManager.AbleToInput)
                ReceiveInputSignal();

            if (Physics2D.Raycast(transform.position, Vector2.down, 3f, layerMask) &&
                !Physics2D.Raycast(transform.position, Vector2.right, 0.8f, layerMask) &&
                !Physics2D.Raycast(transform.position, Vector2.left, 0.8f, layerMask)
                )
            {
                _lastFromPosition = transform.position;
            }

            if (transform.position.y <= -9)
            {
                Respawn();
            }
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
                _direction.x = -1;
                direction = new Vector2(-1,1);
            }
            if (Input.GetKey(inputSignal.rightSide))
            {
                _direction.x = 1;
                direction = new Vector2(1,1);
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
        }

        private void Respawn()
        {
            transform.position = _lastFromPosition;
            currentHealth -= 1;

            if (currentHealth <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }

        public void GetHit()
        {
            currentHealth -= 1;
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    [System.Serializable]
    public class InputSignal
    {
        [Header("左")] public KeyCode leftSide;
        [Header("右")] public KeyCode rightSide;
        [Header("跳")] public KeyCode jump;
        [Header("射击")] public KeyCode fire;
        [Header("冲刺")] public KeyCode dash;
    }
}
