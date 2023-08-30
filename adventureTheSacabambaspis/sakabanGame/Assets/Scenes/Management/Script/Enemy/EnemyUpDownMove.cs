using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpDownMove : MonoBehaviour
{
    public float speed = 1.0f;        // �ړ����x
    public float moveRange = 3.0f;    // �ړ��͈�
    private Vector2 startPosition;    // �����ʒu


    private void Start()
    {
        startPosition = transform.position;   // �����ʒu��ۑ�
    }


    private void Update()
    {
        // sin�֐����g�p���Ĉʒu���v�Z����
        float newYPosition = startPosition.y + Mathf.Sin(Time.time * speed) * moveRange;

        // �V�����ʒu�ɃI�u�W�F�N�g���ړ�
        transform.position = new Vector2(startPosition.x, newYPosition);
    }
}