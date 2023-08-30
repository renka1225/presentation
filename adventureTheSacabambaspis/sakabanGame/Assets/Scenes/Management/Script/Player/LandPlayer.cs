using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandPlayer : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 400.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    public int playerHP = 5;             // �v���C���[��HP
    private Vector2 moveDirection;       // �ړ�����
    private Vector3 startPosition;       // �X�^�[�g�ʒu
    private Rigidbody2D rb2D;
    private Animator animator;           // Player��Animator

    public AudioClip hitSE;              // �G�ɓ��������Ƃ��̉�
    public AudioClip shotSE;             // �e�𔭎˂����Ƃ��̉�
    public AudioClip recoverySE;         // �񕜂��Ƃ����Ƃ��̉�
    private AudioSource audioSource;     // ����

    public GameObject bulletPrefab;      // �e��Prefab
    public float bulletSpeed = 10.0f;    // �e�̑��x
    public int bulletNum = 30;           // �e��
    public Transform firePoint;          // �e�𔭎˂���ʒu

    GameObject bulletManager;           // UI�̎c�e�Ǘ�
    public int bulletRecovery = 5;       // �e���񕜃A�C�e��
    public int hpRecovery = 1;           // HP�񕜃A�C�e��



    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();

        rb2D = GetComponent<Rigidbody2D>();         // Rigidbody2D�̃R���|�[�l���g���擾
        animator = GetComponent<Animator>();        // Animator�̃R���|�[�l���g���擾
        audioSource = GetComponent<AudioSource>();  // AudioSource�R���|�[�l���g���擾
        startPosition = transform.position;         // �����ʒu��ۑ�
        this.bulletManager = GameObject.Find("RemainingBulletsManagement");     // �c�e�̊Ǘ�
        animator.Play("SkyBsps");   // Animation�Đ�

    }

    // Update is called once per frame
    void Update()
    {
        // �W�����v����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // ���E�ړ�
        int key = 0;
        if (Input.GetKey(KeyCode.D)) key = 1;
        if (Input.GetKey(KeyCode.A)) key = -1;

        // �v���C���̑��x
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // �X�s�[�h����
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // ���������ɉ����Ĕ��]
        if (key != 0)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 1);
        }

        // �e�𔭎�
        if (Input.GetKeyDown(KeyCode.Return) && (bulletNum > 0))
        {
            Shoot();

            bulletNum--;
            this.bulletManager.GetComponent<BulletNum>().Firing();
        }
    }


    // �e�𔭎˂���
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.right * bulletSpeed;  // �e���E�����ɔ���
        audioSource.PlayOneShot(shotSE); // �e�𔭎˂���SE
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        // Enemy�܂��̓M�~�b�N�ɓ��������Ƃ��̏���
        if (collision.CompareTag("Enemy") || collision.CompareTag("gimmick") || collision.CompareTag("SkyBoss"))
        {
            audioSource.PlayOneShot(hitSE); // �G�ɓ�������SE
            playerHP--;     // HP��1���炷

            // HP��UI�\��
            GameObject HP = GameObject.Find("Hp");  // Hp�X�N���v�g���擾
            HP.GetComponent<Hp>().DeleteHp();       // Hp�X�N���v�g��DeleteHp�֐����Ăяo��

            // HP��0�ɂȂ�����Q�[���I�[�o�[
            if (playerHP > 0)
            {
                // HP��1�ȏ�Ȃ� EnemyTouch �A�j���[�V�������Đ�
                animator.Play("EnemyTouch");
                animator.SetTrigger("PlayEnemyTouch");

                StartCoroutine(AnimationCoroutine());

            }
            if (playerHP <= 0)
            {
                // �R���[�`���̋N��
                StartCoroutine(GameOverCoroutine());
            }
        }

        // �ǂɋ��܂ꂽ���̏���
        if (collision.CompareTag("Wall"))
        {
            // �X�e�[�W�̍ŏ�����ĊJ
            transform.position = startPosition;
        }

        // ��ɓ��������ۂ̏���
        if (collision.CompareTag("Hand"))
        {
            // �R���[�`���̋N��
            StartCoroutine(DelayCoroutine());
        }

        // �c�e��
        if (collision.CompareTag("bulleRecovery"))
        {
            audioSource.PlayOneShot(recoverySE); // ��SE
            bulletNum += bulletRecovery;
            this.bulletManager.GetComponent<BulletNum>().Recovery();
            collision.gameObject.SetActive(false);
        }

        // HP��
        if (collision.CompareTag("HpRecovery"))
        {
            audioSource.PlayOneShot(recoverySE); // ��SE
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
            // �R���[�`���̋N��
            StartCoroutine(GameOverCoroutine());
        }
    }


    // �R���[�`���̋N��
    IEnumerator AnimationCoroutine()
    {
        // 2�b�ԑ҂�
        yield return new WaitForSeconds(2);

        // Animation�Đ�
        animator.Play("SkyBsps");
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
        // Animation�Đ�
        animator.Play("GameOver");

        bulletNum = 0;

        // 2�b�ԑ҂�
        yield return new WaitForSeconds(2);

        // GameOver��ʂɑJ��
        SceneManager.LoadScene("GameOverScene");
    }
}
