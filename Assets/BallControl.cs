using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField] Vector2 speed;
    [SerializeField] Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        //speed = new Vector2(Random.Range(-5,6), Random.Range(-5,6));
        rigid.velocity = speed.normalized * 5;
    }
}
