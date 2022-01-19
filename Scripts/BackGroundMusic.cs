using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public static bool Continue = false;
    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();
        backgroundMusic.Play();
    }
    void Update()
    {
        if(GameManager.GameOver==true)
        {
            backgroundMusic.Stop();
        }
        if(Continue)
        {
            backgroundMusic.Play();
            Continue = false;
        }

    }


}
