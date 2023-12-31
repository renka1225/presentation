using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloorSide : MonoBehaviour
{
    public float left;              // 上に上がる
    public float right;           // 下に下がる
    public float exchange = 0.03f;  // 上下反転

    void Start()
    {
        left = gameObject.transform.position.x + 3f;
        right = gameObject.transform.position.x - 3f;
    }

    void Update()
    {
        if (gameObject.transform.position.x > left)
        {
            exchange = -0.03f;
        }

        if (gameObject.transform.position.x < right)
        {
            exchange = 0.03f;
        }

        gameObject.transform.Translate(exchange, 0, 0);
    }
}
