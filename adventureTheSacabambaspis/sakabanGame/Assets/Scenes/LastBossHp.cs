using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastBossHp : MonoBehaviour
{
    public int HP = 3;    // Enemy��HP

    // Player�̒e�ɓ��������Ƃ��̏���
    public void Damage(int bulletDamage)
    {
        HP -= bulletDamage;   // HP��1���炷

        if (HP <= 0)
        {
            // �R���[�`���̋N��
            StartCoroutine(ChangeCoroutine());
        }
    }


    IEnumerator ChangeCoroutine()
    {
        // 5�b�ԑ҂�
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("End1");  // �J��
    }
}
