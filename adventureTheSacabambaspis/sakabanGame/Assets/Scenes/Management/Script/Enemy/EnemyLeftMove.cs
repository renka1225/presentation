using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeftMove : MonoBehaviour
{
    public float speed = 5.0f;  // �ړ����x
    private Rigidbody2D rb2D;   // Rigidbody2D���`


    private void Start()
    {
        // Rigidbody2D�̃R���|�[�l���g���擾
        rb2D = GetComponent<Rigidbody2D>();
    }


    // �������Z�̏���
    private void FixedUpdate()
    {
        Vector2 move = new Vector2(-speed, 0);  // �������Ɉړ�
        rb2D.velocity = new Vector2(move.x, rb2D.velocity.y);
    }
}