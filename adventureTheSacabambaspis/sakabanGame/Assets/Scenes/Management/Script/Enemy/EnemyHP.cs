using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int HP = 3;    // Enemy��HP

    // Player�̒e�ɓ��������Ƃ��̏���
    public void Damage(int bulletDamage)
    {
        HP -= bulletDamage;   // HP��1���炷
        
        if(HP <= 0)
        {
            Destroy(gameObject);    // �G��������
        }
    }
}
