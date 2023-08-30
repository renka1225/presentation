using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange4 : MonoBehaviour
{
    public AudioClip decisionSE;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            audioSource.PlayOneShot(decisionSE);

            SceneManager.LoadScene("SkyScene1");
        }
    }
}
