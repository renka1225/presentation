using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houdai2Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;    // �e��Prefab
    public Transform firePoint;        // �e�𔭎˂���ʒu
    public float bulletSpeed = 5.0f;   // �e�̑��x
    public float fireInterval = 1.0f;  // ���˂��鎞�Ԃ̊Ԋu

    private float lastFireTime;        // �Ō�ɒe�𔭎˂�������

    void Start()
    {
        lastFireTime = -fireInterval; // ���������ɍŏ��̔��˂�������
    }

    void Update()
    {
        // �o�ߎ��Ԃ����ˊԊu�𒴂�����e�𔭎�
        if (Time.time - lastFireTime >= fireInterval)
        {
            Shoot();
            lastFireTime = Time.time; // ���ˎ��Ԃ��X�V
        }
    }

    // �e�𔭎˂���
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.left * bulletSpeed + Vector2.up * bulletSpeed;  // �e����������ɔ���
    }
}
