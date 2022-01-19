using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RemoveBlood());
    }
    private IEnumerator RemoveBlood()
    {
        yield return new WaitForSeconds(0.182f);
        Destroy(gameObject);
    }
}
