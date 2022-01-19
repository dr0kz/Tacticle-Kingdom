using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeteorInstantiating : MonoBehaviour
{
    public Meteor meteorPrefab;
    public Transform meteorLeftBorder;
    public Transform meteorRightBorder;
    private float spawnPosition;
    private float MeteorDuration = 0f;

    public AudioSource audio;
    public CameraShake shake;

    void Start()
    {
        audio.GetComponent<AudioSource>();
    }
    void Update()
    {
        if (GameManager.GameOver)
        {
            audio.Stop();
        }
    }
    public void MeteorsAbility()
    {
        InvokeRepeating("meteorSpawn", 0f, 0.1f);
        StartCoroutine(shake.Shake(6f, 0.15f));
        audio.Play();
    }
    private void meteorSpawn()
    {
        MeteorDuration += 0.1f;
        if (MeteorDuration >= 3.8f)
        {
            MeteorDuration = 0f;
            CancelInvoke();
        }
        spawnPosition = Random.Range(meteorLeftBorder.position.x, meteorRightBorder.position.x);
        Vector3 newPos = new Vector3(spawnPosition, meteorLeftBorder.position.y, 0f);
        Meteor meteor = Instantiate(meteorPrefab, newPos, Quaternion.Euler(0f, 180f, 30f));
    }

}
