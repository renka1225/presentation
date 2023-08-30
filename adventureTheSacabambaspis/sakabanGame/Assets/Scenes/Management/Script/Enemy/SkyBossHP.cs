using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyBossHP : MonoBehaviour
{
    public int HP = 6;                      // boss��HP
    Animator animator;                      // Animator�R���|�[�l���g
 //   public Sprite[] bossSprites;            // boss�̃X�v���C�g���i�[����z��
 //   private SpriteRenderer spriteRenderer;  // boss��SpriteRenderer�R���|�[�l���g

    private void Start()
    {
        // SpriteRenderer�̃R���|�[�l���g���擾
        //spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
    }

    // Player�̒e�ɓ��������Ƃ��̏���
    public void Damage(int bulletDamage)
    {
        HP -= bulletDamage;   // HP��1���炷

        //if(HP > 0 && HP <= 6)
        //{
        //   spriteRenderer.sprite = bossSprites[HP - 1];
        //}

        if(HP == 5)
        {
            animator.Play("boss1");
        }
        if(HP == 4)
        {
            animator.Play("boss2");
        }
        if(HP == 3)
        {
            animator.Play("boss3");
        }
        if(HP == 2)
        {
            animator.Play("boss4");
        }
        if(HP == 1)
        {
            animator.Play("boss5");
        }
        if (HP <= 0)
        {
            SceneManager.LoadScene("SkyBossCut1");  // HP��0�ɂȂ�����J��
        }
    }
}
