using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndChange3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �R���[�`���̋N��
        StartCoroutine(ChangeCoroutine());
    }

    IEnumerator ChangeCoroutine()
    {
        // 2�b�ԑ҂�
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("EndingScene");  // �J��
    }

}
