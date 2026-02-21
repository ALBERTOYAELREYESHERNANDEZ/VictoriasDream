using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Intro : MonoBehaviour
{

    

    public void intro()
    {
        LevelLoader.LoadLevel("House");
        //SceneManager.LoadScene("House");
    }

    public void nivelpass()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LevelLoader.LoadLevel("LOGIN");
            Debug.Log("Pass");
        }

            
        //SceneManager.LoadScene("House");
    }


}
