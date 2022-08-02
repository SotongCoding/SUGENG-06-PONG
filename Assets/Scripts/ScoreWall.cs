using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreWall : MonoBehaviour
{
    [SerializeField] bool isRightWall;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ball"))
        {
            ScoreManager.Instance.IncreaseScore(!isRightWall);
            other.GetComponent<BallControl>().ResetPos();
        }
    }
}
