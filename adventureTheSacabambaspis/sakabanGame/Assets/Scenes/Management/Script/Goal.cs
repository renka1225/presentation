using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
  
    // Player���S�[���ɐG�ꂽ��N���A��ʂɑJ��
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // �N���A��ʂɈړ�����
            SceneManager.LoadScene("ResultScene");
        }
    }
}