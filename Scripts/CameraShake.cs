using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration,float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0f;

        while(elapsed<duration && GameManager.Paused==false)
        {
            if(GameManager.GameOver)
            {
                elapsed = duration;
            }
            float x = originalPos.x+Random.Range(-0.4f, 0.4f) * magnitude;
            float y = originalPos.y+Random.Range(-0.4f, 0.4f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
