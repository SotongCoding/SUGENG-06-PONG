using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] Vector2 speed;
    [SerializeField] Rigidbody2D rigid;

    internal void ResetPos()
    {
        transform.position = Vector3.zero;
        rigid.velocity = Vector3.zero;

        Invoke("ThrowBall", 3);
    }

    void ThrowBall()
    {
        speed = new Vector2(Random.Range(-10, 11), Random.Range(-10, 11));
        rigid.velocity = speed.normalized * 5;

        Debug.Log("Ball Speed : " + rigid.velocity);
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ThrowBall();
    }
}
