using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public int damage = 1;  // 弾のダメージ


    void Start()
    {
        // 弾を発射するSEを再生
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
            Destroy(gameObject);    // 弾を消す
        }
    }

    // 弾が画面外に出たら削除
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
