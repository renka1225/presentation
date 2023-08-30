using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoFinished; // ���悪�I��������OnVideoFinished���Ă�
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene("SkyBossScene2"); // ���悪�I�������玟�̃V�[����
    }
}
