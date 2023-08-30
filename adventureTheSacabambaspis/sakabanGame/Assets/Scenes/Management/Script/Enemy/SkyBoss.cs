using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoss : MonoBehaviour
{
    public float speed = 5.0f;         // �ړ����x
    public float jumpForce = 5.0f;     // �W�����v��

    private Rigidbody2D rb;
    private bool isMovingRight = true;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.right;  // �E�����Ɉړ�����
    }

    void Update()
    {
        // �W�����v
        if(Mathf.Abs(rb.velocity.y) < 0.01f)    // �n�ʂɂ���Ƃ�
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        // ���E�ړ�
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }


    // �ǂƂ̓����蔻��
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if(isMovingRight)
            {
                direction = Vector2.left;
                isMovingRight= false;
            }
            else
            {
                direction = Vector2.right;
                isMovingRight = true;
            }
        }
    }
}
