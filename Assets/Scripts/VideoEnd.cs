using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoEnd : MonoBehaviour
{
   
        public VideoPlayer videoPlayer;
        void Start()
        {
            videoPlayer.loopPointReached += EndReached;
        }
        void EndReached(VideoPlayer vp)
        {
            LevelLoader.LoadLevel("MENU");
        }
    
}
