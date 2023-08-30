using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SeaPlayer : MonoBehaviour
{
    public int playerHP = 5;             // �v���C���[��HP
    public float speedX = 5.0f;          // �v���C���[��X�������̈ړ����x
    public float speedY = 3.0f;          // �v���C���[��Y�������̈ړ����x
    private float moveX;                 // X���̈ړ�����
    private float moveY;                 // Y���̈ړ�����
    private Vector2 moveDirection;       // �ړ�����
    private Vector3 startPosition;       // �X�^�[�g�ʒu
    private Rigidbody2D rb2D;
    private Animator animator;           // Player��Animator

    public GameObject bulletPrefab;      // �e��Prefab
    public int bulletNum = 30;           // �e��
    public float bulletSpeed = 10.0f;    // �e�̑��x
    public Transform firePoint;          // �e�𔭎˂���ʒu
    GameObject bulletManager;            // UI�̎c�e�Ǘ�

    public int bulletRecovery = 5;       // �e���񕜃A�C�e��
    public int hpRecovery = 1;           // HP�񕜃A�C�e��

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();     // Rigidbody2D�̃R���|�[�l���g���擾
        animator = GetComponent<Animator>();    // Animator�̃R���|�[�l���g���擾
        startPosition = transform.position;     // �����ʒu��ۑ�
        this.bulletManager = GameObject.Find("RemainingBulletsManagement");
    }

    void Update()
    {
        moveX = 0;
        moveY = 0;

        
        if (Input.GetKey(KeyCode.A))    // ������
        {
            moveX = -speedX;
        }
        if (Input.GetKey(KeyCode.D))    // �E����
        {
            moveX = speedX;
        }
        if (Input.GetKey(KeyCode.W))    // �����
        {
            moveY = speedY;
        }
        if (Input.GetKey(KeyCode.S))    // ������
        {
            moveY = -speedY;
        }
        moveDirection = new Vector2(moveX, moveY).normalized;

        // �e�𔭎�
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Shoot();
        }
    }

    // Rigidbody�̑��x���X�V
    void FixedUpdate()
    {
        rb2D.velocity = moveDirection * new Vector2(speedX, speedY);
    }

    // �e�𔭎˂���
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.right * bulletSpeed;  // �e���E�����ɔ���
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Enemy�܂��̓M�~�b�N�ɓ��������Ƃ��̏���
        if (collision.CompareTag("Enemy") || collision.CompareTag("gimmick"))
        {
            playerHP--;   // HP��1���炷

            // HP��0�ɂȂ�����Q�[���I�[�o�[
            if (playerHP <= 0)
            {
                // Animation�Đ�
                animator.Play("GameOver");
                // �R���[�`���̋N��
                StartCoroutine(GameOverCoroutine());
            }
        }

        // �ǂɋ��܂ꂽ���̏���
        if(collision.CompareTag("Wall"))
        {
            // �X�e�[�W�̍ŏ�����ĊJ
            transform.position = startPosition;
        }

        // ��ɓ��������ۂ̏���
        if(collision.CompareTag("Hand"))
        {
            // �R���[�`���̋N��
            StartCoroutine(DelayCoroutine());
        }

        // �c�e��
        if (collision.CompareTag("bulleRecovery"))
        {
            bulletNum += bulletRecovery;
            this.bulletManager.GetComponent<BulletNum>().Recovery();
            collision.gameObject.SetActive(false);
        }

        // HP��
        if (collision.CompareTag("HpRecovery"))
        {
            playerHP += hpRecovery;
            if (playerHP >= 6)
            {
                playerHP = 5;
            }
            GameObject hpDelete = GameObject.Find("HpDelete");
            hpDelete.GetComponent<Hp>().RecoveryHp();
            collision.gameObject.SetActive(false);
        }

    }

    // �G�̒e�ɓ��������ۂ̏���
    public void TakeDamage(int damage)
    {
        playerHP -= damage;

        if (playerHP <= 0)
        {
            // Animation�Đ�
            animator.Play("GameOver");
            // �R���[�`���̋N��
            StartCoroutine(GameOverCoroutine());
        }
    }


    // Player�폜�̃R���[�`��
    IEnumerator DelayCoroutine()
    {
        // 1�b�ԑ҂�
        yield return new WaitForSeconds(1);

        // Player�̍폜
        Destroy(gameObject);
    }


    // GameOver�̃R���[�`��
    IEnumerator GameOverCoroutine()
    {
        // 1�b�ԑ҂�
        yield return new WaitForSeconds(1);

        // GameOver��ʂɑJ��
        SceneManager.LoadScene("GameOverScene");
    }

}
