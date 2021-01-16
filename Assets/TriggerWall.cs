using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWall : MonoBehaviour
{
    public GameObject wall;
    public float secs;
    public bool noEnemies;
    public int nEnemies;
    public bool enemiesSpawned;
    Collider[] collidersHit;
    public Vector3 roomSize;
    public LayerMask enemyLayers;
    public GameObject enemies;

    IEnumerator SetOffWall()
    {
        yield return new WaitForSeconds(secs);
        wall.SetActive(false);
    }

    void countEnemies()
    {
        collidersHit = Physics.OverlapBox(new Vector3(transform.position.x, transform.position.y, transform.position.z - 4.5f), roomSize / 2, Quaternion.identity, enemyLayers);
        nEnemies = collidersHit.Length;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnEnemies();
            countEnemies();
            if (nEnemies == 0 && enemiesSpawned)
            {
                noEnemies = true;
            }
            if (noEnemies)
            {
                StartCoroutine(SetOffWall());
            }
        }

    }

    public void SpawnEnemies()
    {
        if (!enemiesSpawned)
        {
            Instantiate(enemies, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Instantiate(enemies, new Vector3(transform.position.x-5, transform.position.y, transform.position.z - 4.5f), Quaternion.identity);
            Instantiate(enemies, new Vector3(transform.position.x +5, transform.position.y, transform.position.z - 4.5f), Quaternion.identity);
        }
        enemiesSpawned = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y, transform.position.z-4.5f), roomSize);
    }
}
