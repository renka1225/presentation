using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class same : MonoBehaviour
{
    public float speed = 9.0f;              // �ړ����x
    private Rigidbody2D rb2D;               // Rigidbody2D���`

    // �A�j���[�V�����Đ�
    public float animationDistance = 10.0f;  // ���̋������Ƀv���C���[����������A�j���[�V�������J�n
    private Animator animator;              // same��Animator
    private Transform player;               // Player��Transform


    private void Start()
    {
        // Rigidbody2D�̃R���|�[�l���g���擾
        rb2D = GetComponent<Rigidbody2D>();
        // Animator�̃R���|�[�l���g���擾
        animator = GetComponent<Animator>();

        // Player�^�O��Transform���擾
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void Update()
    {
        // �G�ƃv���C���[�Ƃ̋������v�Z
        float distance = Vector2.Distance(transform.position, player.position);

        // �������ɓ�������A�j���[�V�������J�n
        if (distance <= animationDistance)
        {
            animator.Play("same");
        }
    }


    // �������Z�̏���
    private void FixedUpdate()
    {
        Vector2 move = new Vector2(-speed, 0);  // �������Ɉړ�
        // rigidbody2D��velocity(���x)�֎擾����speed��������
        rb2D.velocity = new Vector2(move.x, rb2D.velocity.y);
    }
}