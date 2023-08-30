using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneSwitch : MonoBehaviour
{
    public AudioClip selectSE;            // Space���������Ƃ��̉�
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.PlayOneShot(selectSE);

        // �^�C�g������Z���N�g��
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("StageSelectScene");
        }

        // �z�[������^�C�g����
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
