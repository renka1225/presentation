using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bulletPrefab;    // 弾のPrefab
    public Transform firePoint;        // 弾を発射する位置
    public float bulletSpeed = 5.0f;   // 弾の速度
    public float fireInterval = 1.0f;  // 発射する時間の間隔

    private float lastFireTime;        // 最後に弾を発射した時間

    void Start()
    {
        lastFireTime = -fireInterval; // 初期化時に最初の発射を許可する
    }

    void Update()
    {
        // 経過時間が発射間隔を超えたら弾を発射
        if (Time.time - lastFireTime >= fireInterval)
        {
            Shoot();
            lastFireTime = Time.time; // 発射時間を更新
        }
    }

    // 弾を発射する
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.left * bulletSpeed;  // 弾を左方向に発射
    }
}
