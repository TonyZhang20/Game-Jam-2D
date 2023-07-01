using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.PlayerControl
{
    public class Fire : MonoBehaviour
    {
        [SerializeField,Header("小球生成时添加的力")]private Vector2 force;
        [SerializeField, Header("开火间隔")] private float cooldown = 0.1f;
        [SerializeField] private GameObject fireball;
        private PlayerController _playerController;
        private bool _ableFire = true;
        private void Start()
        {
            _playerController = GetComponent<PlayerController>();
        }

        private void Update()
        {
            if(GameManager.AbleToInput && _ableFire)
                if(Input.GetKeyDown(_playerController.inputSignal.fire)) FireBall();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void FireBall()
        {
            var ball = Instantiate(fireball);
            var body = ball.GetComponent<Rigidbody2D>();
            var direction = _playerController.direction;

            ball.transform.position = gameObject.transform.position;
            body.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,0);
            body.AddForce(force * direction);
            _ableFire = false;
            Invoke(nameof(AbleToFire),cooldown);
        }

        private void AbleToFire()
        {
            _ableFire = true;
        }
    }
}
