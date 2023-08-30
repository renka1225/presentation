using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneSwitch : MonoBehaviour
{
    public AudioClip backSE;          // A���������Ƃ��̉�
    public AudioClip selectSE;		  // Space���������Ƃ��̉�
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // �Q�[���I�[�o�[����z�[����
        if (Input.GetKeyDown(KeyCode.A))
        {
            audioSource.PlayOneShot(backSE);
            SceneManager.LoadScene("HomeScene");
        }

        // �Q�[���I�[�o�[����Z���N�g��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(selectSE);
            SceneManager.LoadScene("StageSelectScene");
        }
    }
}
