using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaBossAttack1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �t���[�����Ƃɓ����ŗ���������
        transform.Translate(0, 0.001f, 0);

        // ��ʊO�ɏo����I�u�W�F�N�g��j������
        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
