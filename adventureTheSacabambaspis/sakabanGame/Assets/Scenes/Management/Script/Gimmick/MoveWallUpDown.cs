using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallUpDown : MonoBehaviour
{
    public float top;               // 上に上がる
    public float bottom;            // 下に下がる
    public float exchange = -1.0f;  // 上下反転

    void Start()
    {
        top = gameObject.transform.position.y + 3f;
        bottom = gameObject.transform.position.y - 3f;
    }

    void Update()
    {
        if (gameObject.transform.position.y > top)
        {
            exchange = -0.03f;
        }

        if (gameObject.transform.position.y < bottom)
        {
            exchange = 0.03f;
        }
        gameObject.transform.Translate(0, exchange, 0);
    }
}
