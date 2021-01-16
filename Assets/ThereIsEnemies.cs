using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThereIsEnemies : MonoBehaviour
{
    public GameObject lDoor, rDoor;
    public GameObject lDoorEntrance, rDoorEntrance;
    public LayerMask enemyLayers;
    public int nEnemies;
    public bool enemiesSpawned;
    public Vector3 roomSize;
    Collider[] collidersHit;
    public GameObject enemies;
    //public Transform spawner;


    void countEnemies()
    {
        collidersHit = Physics.OverlapBox(new Vector3(transform.position.x, transform.position.y+4, transform.position.z-43), roomSize/2, Quaternion.identity,enemyLayers);
        nEnemies = collidersHit.Length;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            lDoorEntrance.SetActive(true);
            rDoorEntrance.SetActive(true);
            SpawnEnemies();
            countEnemies();
            if(nEnemies == 0 && enemiesSpawned)
            {
                lDoor.SetActive(false);
                rDoor.SetActive(false);
                lDoorEntrance.SetActive(false);
                rDoorEntrance.SetActive(false);
            }
        }
    }

    public void SpawnEnemies()
    {
        if (!enemiesSpawned)
        {
            Instantiate(enemies, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z - 43), Quaternion.identity);
            Instantiate(enemies, new Vector3(transform.position.x + 5, transform.position.y + 3, transform.position.z - 43), Quaternion.identity);
            Instantiate(enemies, new Vector3(transform.position.x - 5, transform.position.y + 3, transform.position.z - 43), Quaternion.identity);
        }
        enemiesSpawned = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y+4, transform.position.z-43), roomSize);
    }

}
