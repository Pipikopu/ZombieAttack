using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButtonManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public int sceneIndex;
    public GameObject videoPlayerHolder;

    // Start is called before the first frame update

    private void Start()
    {
        videoPlayer.enabled = false;
        videoPlayerHolder.SetActive(false);
    }

    public void PlayVideo()
    {
        if (videoPlayer)
        {
            videoPlayer.enabled = true;
            videoPlayerHolder.SetActive(true);
        }
    }

    public void StopVideo()
    {
        if (videoPlayer)
        {
            videoPlayer.enabled = false;
            videoPlayerHolder.SetActive(false);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
