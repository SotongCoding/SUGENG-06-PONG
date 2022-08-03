using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] Vector2 speed;
    [SerializeField] Rigidbody2D rigid;

    public PaddleControl lastTouchPaddle { private set; get; }

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ThrowBall();
    }
    internal void ResetPos()
    {
        transform.position = Vector3.zero;
        rigid.velocity = Vector3.zero;

        Invoke("ThrowBall", 3);
    }

    void ThrowBall()
    {
        speed = new Vector2(Random.Range(-10, 11), Random.Range(0, 2) >= 0 ? 1 : -1);
        rigid.velocity = speed.normalized * 5;

        Debug.Log("Ball Speed : " + rigid.velocity);
    }


    internal void IncreaseSpeed(float multipleSpeed)
    {
        rigid.velocity *= Mathf.Clamp(multipleSpeed, 1, 2);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("paddle"))
        {
            lastTouchPaddle = other.gameObject.GetComponent<PaddleControl>();
        }
    }
}
