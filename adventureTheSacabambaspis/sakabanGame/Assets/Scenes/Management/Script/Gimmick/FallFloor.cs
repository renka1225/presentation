using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFloor : MonoBehaviour
{
    public float speed = 0.1f;  // ���̗����鑬��
    private float fallCount;    // ����������܂ł̎���
    private bool floorTouch;    // �v���C���[�����ɐG�ꂽ���̔���
    private Rigidbody2D rb2D;



    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();     // Rigidbody2D�̃R���|�[�l���g���擾
        fallCount = 0;                          // fallCount�̏�����
    }

    void Update()
    {
        // ���ɐG�ꂽ��
        if(floorTouch == true)
        {
            // fallCount�𑝂₷
            fallCount += Time.deltaTime;

            DownStart();
        }
    }

    // �����蔻��
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.tag == "Player")
        {
            fallCount = 0;      // fallCount�̏�����
            floorTouch = true;  // floorTouch��true�ɂ���
        }
    }

    // ���b��ɏ���������
    void DownStart()
    {
        if(fallCount>= 0.5f)
        {
            transform.Translate(0, -speed, 0);
        }
    }
}
