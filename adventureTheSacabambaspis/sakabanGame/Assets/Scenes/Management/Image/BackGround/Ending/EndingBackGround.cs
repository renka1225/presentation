using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingBackGround : MonoBehaviour
{
    public List<Sprite> endingBackgrounds; // �G���f�B���O�̔w�i�̃��X�g
    private SpriteRenderer spriteRenderer; // SpriteRenderer�R���|�[�l���g

    private int currentIndex = 0; // ���݂̔w�i�摜�̃C���f�b�N�X

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer�R���|�[�l���g�̎擾
        StartCoroutine(ChangeBackgroundCoroutine());    // �R���[�`���̊J�n
    }

    IEnumerator ChangeBackgroundCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f); // 3�b�ҋ@

            currentIndex++; // �C���f�b�N�X���C���N�������g

            spriteRenderer.sprite = endingBackgrounds[currentIndex]; // �w�i�摜�̕ύX
        }
    }
}
