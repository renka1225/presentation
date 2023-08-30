using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeftRightMove : MonoBehaviour
{
    public float speed = 5.0f;          // �ړ����x
    public float moveDistance = 10.0f;  // ���E�Ɉړ����鋗��

    private float leftEnd;              // ���[
    private float rightEnd;             // �E�[
    private int direction = -1;         // �ړ������i1: �E�A-1: ���j

    private void Start()
    {
        // ���[�ƉE�[�̈ʒu���v�Z
        leftEnd = transform.position.x - moveDistance;
        rightEnd = transform.position.x + moveDistance;
    }

    private void Update()
    {
        // ���݂̈ʒu���X�V
        transform.position += new Vector3(speed * direction * Time.deltaTime, 0, 0);

        // �������[�܂��͉E�[�ɓ��B������A�����𔽓]
        if (transform.position.x > rightEnd || transform.position.x < leftEnd)
        {
            direction *= -1;  // �����𔽓]

            // sprite�̌����𔽓]
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}