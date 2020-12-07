using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWall : MonoBehaviour
{
    public GameObject wall;
    public float secs = 3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SetOffWall());
        }
    }

    IEnumerator SetOffWall()
    {
        yield return new WaitForSeconds(secs);
        wall.SetActive(false);
    }
}
