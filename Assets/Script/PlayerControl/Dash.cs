using UnityEngine;
using UnityEngine.Serialization;

namespace Script.PlayerControl
{
    public class Dash : MonoBehaviour
    {
        public float sprintSpeed = 10f;  // 冲刺速度
        public float sprintDuration = 0.5f;  // 冲刺持续时间
        [SerializeField, Header("冲刺计时器")]private float sprintTimer = 0f;  // 冲刺计时器
        private bool _isSprinting;  // 是否正在冲刺
        private Vector2 _sprintDirection;  // 冲刺方向
        private Rigidbody2D _rb;
        private PlayerController _playerController;
        public bool ableToDash = true;
        [SerializeField,Header("冲刺冷却时间")]private float dashCoolDown = 2f;

        private void Start()
        {
            _playerController = GetComponent<PlayerController>();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(_playerController.inputSignal.dash) && GameManager.AbleToInput && ableToDash)
            {
                StartSprinting();
                
                ableToDash = false;
                Invoke(nameof(DashCoolDown), dashCoolDown);
            }

            if (_isSprinting)
            {
                sprintTimer -= Time.deltaTime;

                if (sprintTimer <= 0f)
                {
                    StopSprinting();
                }
            }
        }

        private void DashCoolDown()
        {
            ableToDash = true;
        }

        private void FixedUpdate()
        {
            if (_isSprinting)
            {
                _rb.velocity = _sprintDirection * sprintSpeed;
            }
        }

        private void StartSprinting()
        {
            gameObject.layer = LayerMask.NameToLayer("ThroughWall");
            if (!_isSprinting)
            {
                _isSprinting = true;
                sprintTimer = sprintDuration;
                _sprintDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            }
        }

        private void StopSprinting()
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
            _isSprinting = false;
            _rb.velocity = Vector2.zero;
        }
    }
}
