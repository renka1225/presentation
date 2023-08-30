using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int enemyBulletDamage = 1;  // �e�̃_���[�W


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                player.TakeDamage(enemyBulletDamage);
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
