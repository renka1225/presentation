using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoss2 : MonoBehaviour
{
    public float speed = 5.0f;                        // �ړ����x
    public float moveRange = 1.5f;                    // �ړ��͈�
    public float changeTime = 3.0f;                   // �ړI�n�ύX�̊Ԋu
    public Vector2 minMoveArea = new Vector2(-8, -2); // �ŏ��̈ړ��͈�
    public Vector2 maxMoveArea = new Vector2(8, 2);   // �ő�̈ړ��͈�

    private Vector2 targetPosition;    // �ړI�n
    private Rigidbody2D rb2D;



    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        // ���߂̖ړI�n��ݒ肷��
        moveRandomPosition();

        // ��莞�ԂŖړI�n���X�V����
        StartCoroutine(ChangeTargetPosition());
    }


    void Update()
    {
        // �ړI�n�ւ̕����Ƒ��x���v�Z
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        rb2D.velocity = direction * speed;

        // �ړI�n�Ƃ̋������v�Z����
        float distance = Vector2.Distance(transform.position, targetPosition);

        // �ړI�n�ɋ߂Â�����V�����ړI�n��ݒ肷��
        if(distance < 0.1f)
        {
            moveRandomPosition();
        }
    }


    // �����_���ȖړI�n��ݒ�
    void moveRandomPosition()
    {
        float randomX = Random.Range(minMoveArea.x, maxMoveArea.x);
        float randomY = Random.Range(minMoveArea.y, maxMoveArea.y);
        // �V�����ʒu�Ɉړ�
        targetPosition = new Vector2(randomX, randomY);
    }


    // ��莞�ԂŖړI�n���X�V����R���[�`��
    IEnumerator ChangeTargetPosition()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            moveRandomPosition();
        }
        
    }
}