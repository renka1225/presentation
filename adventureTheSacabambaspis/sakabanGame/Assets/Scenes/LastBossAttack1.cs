using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBossAttack1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �t���[�����Ƃɓ����ŉ��ɂ��炷
        transform.Translate(0, 0.01f, 0);

        if (transform.position.y < -10.0f)
        {
            Destroy(gameObject);
        }
        
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
