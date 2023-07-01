using System;
using System.Collections;
using UnityEngine;

namespace Script
{
    public class BallController : MonoBehaviour
    {
        [Range(0,1),SerializeField,Header("反弹的系数")]private float upwardForce;
        [SerializeField, Header("生存时间")] private float aliveTime;

        private void OnEnable()
        {
            Invoke(nameof(DestroyItSelf),aliveTime);
        }

        private void DestroyItSelf()
        {
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // 检查碰撞物体是否为地面
            if (collision.transform.CompareTag("Ground"))
            {
                // 将小球的Y轴速度设置为一个正数，以模拟弹起效果
                Rigidbody2D ballRigidbody = GetComponent<Rigidbody2D>();
                var velocity = ballRigidbody.velocity;
                velocity = new Vector2(velocity.x, upwardForce * velocity.y);
                ballRigidbody.velocity = velocity;
            }

            if (collision.transform.CompareTag("Enemy"))
            {
                collision.transform.GetComponent<Enemy>().GetHit();
                Destroy(gameObject);
            }
        }
    }
}
