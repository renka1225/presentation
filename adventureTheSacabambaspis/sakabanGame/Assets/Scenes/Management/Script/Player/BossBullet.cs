using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public int damage = 1;  // �e�̃_���[�W


    void Start()
    {
        // �e�𔭎˂���SE���Đ�
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SkyBoss"))
        {
            SkyBossHP bossHp = collision.gameObject.GetComponent<SkyBossHP>();

            if (bossHp != null)
            {
                bossHp.Damage(damage);
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
