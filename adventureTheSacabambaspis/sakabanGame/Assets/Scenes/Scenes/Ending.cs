using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    //�@�e�L�X�g�̃X�N���[���X�s�[�h
    private float textScrollSpeed = 280;
    //�@�e�L�X�g�̐����ʒu
    private float limitPosition = 5200f;
    //�@�G���h���[�����I���������ǂ���
    private bool isStopEndRoll;
    //�@�V�[���ړ��p�R���[�`��
    private Coroutine endRollCoroutine;

    
    void Update()
    {
        //�@�G���h���[�����I��������
        if (isStopEndRoll)
        {
            endRollCoroutine = StartCoroutine(GoToNextScene());
        }
        else
        {
            //�@�G���h���[���p�e�L�X�g�����~�b�g���z����܂œ�����
            if (transform.position.y <= limitPosition)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + textScrollSpeed * Time.deltaTime);
            }
            else
            {
                isStopEndRoll = true;
            }
        }
    }

    IEnumerator GoToNextScene()
    {
        //�@1�b�ԑ҂�
        yield return new WaitForSeconds(1f);

        if (Input.GetKeyDown("return"))
        {
            StopCoroutine(endRollCoroutine);
            SceneManager.LoadScene("TitleScene");
        }

        yield return null;
    }
}
