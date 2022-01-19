using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorInstantiating : MonoBehaviour
{
    public Meteor meteorPrefab;
    public Transform meteorLeftBorder;
    public Transform meteorRightBorder;
    private float spawnPosition;
    private float MeteorDuration = 0f;
    public int Price;
    public Button meteorButton;

    public AudioSource audio;
    public CameraShake shake;

    void Start()
    {
        audio.GetComponent<AudioSource>();
    }
    public void MeteorsAbility()
    {
        if(GameManager.GameOver == false && GameManager.Paused == false && DiamondScript.diamondValue >= Price)
        {
            DiamondScript.diamondValue -= Price;
            GameManager.Diamonds = DiamondScript.diamondValue;
            InvokeRepeating("meteorSpawn", 0.1f, 0.1f);
            StartCoroutine(shake.Shake(5.5f,0.15f));
            audio.Play();
            meteorButton.interactable=false;
            StartCoroutine(MeteorButtonDisable());
        }
    }
    void Update()
    {
        if (GameManager.GameOver)
        {
            audio.Stop();
        }
    }
    private IEnumerator MeteorButtonDisable()
    {
        yield return new WaitForSeconds(30f);
        meteorButton.interactable=true;
    }
    private void meteorSpawn()
    {
        MeteorDuration += 0.1f;
        if (MeteorDuration >= 4.5f)
        {
            MeteorDuration = 0f;
            CancelInvoke();
        }
        spawnPosition = Random.Range(meteorLeftBorder.position.x, meteorRightBorder.position.x);
        Vector3 newPos = new Vector3(spawnPosition, meteorLeftBorder.position.y, 0f);
        Meteor meteor = Instantiate(meteorPrefab, newPos, Quaternion.Euler(0f, 0f, 30f));
    }
}
