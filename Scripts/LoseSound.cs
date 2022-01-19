using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseSound : MonoBehaviour
{
    public AudioSource loseSound;
    public static bool isPlaying = false;
    public static bool StopPlaying = false;
    void Update()
    {
        if(GameManager.GameOver && PlayerCastle.CastleHealth == 0 && isPlaying==false)
        {
            isPlaying = true;
            loseSound.Play();
        }
        if(StopPlaying)
        {
            loseSound.Stop();
            isPlaying = false;
            StopPlaying = false;
        }
    }
}
