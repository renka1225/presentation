using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeaBossHp : MonoBehaviour
{
    public int HP = 3;    // Enemy��HP

    // Player�̒e�ɓ��������Ƃ��̏���
    public void Damage(int bulletDamage)
    {
        HP -= bulletDamage;   // HP��1���炷

        if (HP <= 0)
        {
            Destroy(gameObject);    // �G��������

            SceneManager.LoadScene("ResultScene");
        }
    }
}
