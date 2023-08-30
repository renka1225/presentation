using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyBoss2HP : MonoBehaviour
{
    public int HP = 15;                      // boss��HP
    Animator animator;                      // Animator�R���|�[�l���g


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Player�̒e�ɓ��������Ƃ��̏���
    public void Damage(int bulletDamage)
    {
        HP -= bulletDamage;   // HP��1���炷

        if (HP <= 0)
        {
            SceneManager.LoadScene("ResultScene");  // HP��0�ɂȂ�����J��
        }
    }
}
