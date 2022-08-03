using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    [SerializeField] KeyCode moveUp;
    [SerializeField] KeyCode moveDown;
    [SerializeField] float speed;

    float originalSpeed;
    Vector3 originalPaddlesize = new Vector3(0.5f, 2.5f, 1);

    [SerializeField] Rigidbody2D rigid;
    WaitForSeconds buffLastingTime = new WaitForSeconds(5);

    private void Start()
    {
        //Some Comment Here
        rigid = GetComponent<Rigidbody2D>();
        originalSpeed = speed;

    }
    private void Update()
    {
        MovePaddle(GetInput());
        Debug.Log("Speed of Paddle " + gameObject.name + "is " + rigid.velocity);
    }

    Vector2 GetInput()
    {
        if (Input.GetKey(moveUp)) return Vector2.up;
        else if (Input.GetKey(moveDown)) return Vector2.down;
        else return Vector2.zero;

    }
    void MovePaddle(Vector2 movementDir)
    {
        rigid.velocity = movementDir * speed;
        transform.position = new Vector2(transform.position.x,
        Mathf.Clamp(transform.position.y, -3.3f, 3.3f));
    }

    internal void IncreaseLenght(float lengthIncrease)
    {
        transform.localScale = new Vector3(transform.localScale.x,
        transform.localScale.y * lengthIncrease,
        transform.localScale.z);

        StopCoroutine(LengthBuff());
        StartCoroutine(LengthBuff());

        IEnumerator LengthBuff()
        {
            yield return buffLastingTime;
            transform.localScale = originalPaddlesize;
        }
    }

    internal void IncreaseSpeed(float speedIncrease)
    {
        speed *= speedIncrease;
        StopCoroutine(SpeedBuff());
        StartCoroutine(SpeedBuff());

        IEnumerator SpeedBuff()
        {
            yield return buffLastingTime;
            speed = originalSpeed;
        }
    }
}
