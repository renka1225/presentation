using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public float speedY = 0.3f;

    void Update()
    {
        // �t���[�����Ƃɗ���������
        transform.Translate(0, -speedY, 0);
    }

    // stage�Ƃ̓����蔻��𒲂ׂ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���ɂ������ɖ߂�
        if (collision.CompareTag("stage"))
        {
            transform.Translate(0, speedY, 0);
        }
    }
}
