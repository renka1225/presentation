using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloorSide : MonoBehaviour
{
    public float left;              // ��ɏオ��
    public float right;           // ���ɉ�����
    public float exchange = 0.03f;  // �㉺���]

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
