using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBullet2 : MonoBehaviour
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
            SkyBoss2HP bossHp = collision.gameObject.GetComponent<SkyBoss2HP>();

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
