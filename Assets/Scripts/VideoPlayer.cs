using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlayer : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer videoPlayer;
    public UnityEngine.Video.VideoClip videoClip;

	public bool loop;


    public void PlayVideo()
    {
        // Will attach a VideoPlayer to the main camera.
        GameObject camera = GameManager.instance.camera.gameObject;

        // Set the video to play. URL supports local absolute or relative paths.
        // Here, using absolute.
        videoPlayer.clip = videoClip;

        // Restart from beginning when done.
        videoPlayer.isLooping = loop;

        videoPlayer.Play();
    }
    
}
