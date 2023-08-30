using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand2 : MonoBehaviour
{
    public float speed = 5.0f;      // �ړ����x
    private Rigidbody2D rb2D;       // Rigidbody2D���`

    private Animator animator;      // hand��Animator

    private bool isMoving = true;   // hand���ړ����Ă��邩����

    private void Start()
    {
        // Rigidbody2D�̃R���|�[�l���g���擾
        rb2D = GetComponent<Rigidbody2D>();

        // Animator�̃R���|�[�l���g���擾
        animator = GetComponent<Animator>();
    }


    // �������Z�̏���
    private void FixedUpdate()
    {
        if (isMoving)
        {
            Vector2 move = new Vector2(speed, 0);  // �E�����Ɉړ�
            rb2D.velocity = new Vector2(move.x, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = Vector2.zero;   // ��~
        }
    }


    // Player�Ƃ̓����蔻��𒲂ׂ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ڐG�����I�u�W�F�N�g��Player�^�O�������Ă��邩�`�F�b�N
        if (collision.CompareTag("Player"))
        {
            // �A�j���[�V���������s
            animator.Play("hand2");
            isMoving = false;   // Player�ɐڐG�������~
        }
    }
}