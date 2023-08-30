using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip shotSE;    // �e�𔭎˂���SE
    public AudioClip hitSE;     // �e��Enemy�ɓ�������SE
    AudioSource aud;


    public void PlayShotSE()
    {
        aud.PlayOneShot(shotSE);
    }

    public void PlayHitSE()
    {
        aud.PlayOneShot(hitSE);
    }
}
