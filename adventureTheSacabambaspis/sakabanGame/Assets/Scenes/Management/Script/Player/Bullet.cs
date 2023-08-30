using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;  // �e�̃_���[�W


    void Start()
    {
        // �e�𔭎˂���SE���Đ�
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHP enemyHp = collision.gameObject.GetComponent<EnemyHP>();

            if (enemyHp != null)
            {
                enemyHp.Damage(damage);
            }
            Destroy(gameObject);    // �e������
        }

        // �C�X�e�[�W�{�X�p
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SeaBossHp seaBossHp = collision.gameObject.GetComponent<SeaBossHp>();

            if (seaBossHp != null)
            {
                seaBossHp.Damage(damage);
            }
            Destroy(gameObject);    // �e������
        }

        // �ŏI�X�e�[�W�{�X�p
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LastBossHp lastBossHp = collision.gameObject.GetComponent<LastBossHp>();

            if (lastBossHp != null)
            {
                lastBossHp.Damage(damage);
            }
            Destroy(gameObject);    // �e������
        }
    }

    // �e����ʊO�ɏo����폜
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
