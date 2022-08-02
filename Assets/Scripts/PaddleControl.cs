using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    [SerializeField] KeyCode moveUp;
    [SerializeField] KeyCode moveDown;
    [SerializeField] float speed;

    [SerializeField] Rigidbody2D rigid;

    private void Start()
    {
        //Some Comment Here
        rigid = GetComponent<Rigidbody2D>();
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
}
