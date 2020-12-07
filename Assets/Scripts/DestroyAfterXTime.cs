using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterXTime : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroySelf());
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
