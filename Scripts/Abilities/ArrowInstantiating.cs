using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowInstantiating : MonoBehaviour
{
    public Arrow arrowPrefab;
    public Transform arrowLeftBorder;
    public Transform arrowRightBorder;
    private float spawnPosition;
    private float ArrowDuration = 0f;
    public int Price;
    public Button arrowButton;
    public void ArrowsAbility()
    {
        if (GameManager.GameOver == false && GameManager.Paused == false && DiamondScript.diamondValue>Price)
        {
            DiamondScript.diamondValue -= Price;
            GameManager.Diamonds = DiamondScript.diamondValue;
            arrowButton.interactable = false;
            StartCoroutine(EnableArrowButton());
            InvokeRepeating("arrowSpawn", 0f, 0.02f);
        }
    }
    private IEnumerator EnableArrowButton()
    {
        yield return new WaitForSeconds(25f);
        arrowButton.interactable = true;
    }
    private void arrowSpawn()
    {
        ArrowDuration += 0.02f;
        if (ArrowDuration >= 5f)
        {
            ArrowDuration = 0f;
            CancelInvoke();
        }
        spawnPosition = Random.Range(arrowLeftBorder.position.x, arrowRightBorder.position.x);
        Vector3 newPos = new Vector3(spawnPosition, arrowLeftBorder.position.y, 0f);
        Arrow arrow = Instantiate(arrowPrefab, newPos, Quaternion.Euler(0f, 0f, -90f));
    }
}
