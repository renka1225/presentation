using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator animator;      // button��Animator

    private void Start()
    {
        // Animator�̃R���|�[�l���g���擾
        animator = GetComponent<Animator>();
    }


    // Player�Ƃ̓����蔻��𒲂ׂ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ڐG�����I�u�W�F�N�g��Player�^�O�������Ă��邩�`�F�b�N
        if (collision.CompareTag("Player"))
        {
            // �A�j���[�V���������s
            animator.Play("button");

            // Recovery�̃I�u�W�F�N�g���擾
            GameObject recovery = GameObject.Find("Recovery");
            // �I�u�W�F�N�g����
            recovery.transform.Translate(0, -10.0f, 0);
        }
    }
}
