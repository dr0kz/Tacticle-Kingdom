using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCar : MonoBehaviour
{
    public AudioSource audio;
    private float policeCarSpeed = 4.5f;
    public static int playersKilled = 0;
    // Update is called once per frame
    void Start()
    {
        playersKilled = 0;
        audio.Play();
    }
    void Update()
    {
        if(GameManager.GameOver)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * policeCarSpeed * Time.deltaTime);
    }
    public void IncreasePlayersKilled()
    {
        playersKilled++;
    }
    public int getDamage()
    {
        return playersKilled * 100;
    }
}
