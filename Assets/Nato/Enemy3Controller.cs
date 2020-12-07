using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Controller : MonoBehaviour
{
    Transform playerLocation;
    public Vector3[] locations;
    public float speed;
    public int chosen;
    public int plusminus;
    public bool playerDetected;
    public GameObject[] drops;

    public bool spawn;
    bool tp;
    WaitForSeconds tpCoolDown = new WaitForSeconds(3f);
    WaitForSeconds spawnCoolDown = new WaitForSeconds(4f);

    float targetRange = 20f;

    private EnemyBase enemyBase;

    private void Awake()
    {

    }

    void Start()
    {
        enemyBase = this.GetComponent<EnemyBase>();
        //enemyBase.enemyType = EnemyController.EnemyType.ENEMY1;
        enemyBase.currentHealth = enemyBase.maxHealth;
        playerDetected = false;
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
        spawn = true;
        tp = true;
    }

    void Update()
    {
        Controller();
    }

    

    void Findtarget()
    {
        if (Vector3.Distance(transform.position, playerLocation.position) < targetRange)
        {
            playerDetected = true;
        }
        else
        {
            playerDetected = false;
        }
    }

    void Controller()
    {
        if (enemyBase.currentHealth > 0)
        {
            MovementController();
        }
        else
        {
            Die();
        }
    }

    void Die()
    {
        int probDrop = Random.Range(1, 100);
        if(probDrop >= 30)
        {
            Debug.Log("Instancia un drop");
            probDrop = Random.Range(0, drops.Length-1);
            Debug.Log(probDrop);
            Instantiate(drops[probDrop], this.gameObject.transform.position, Quaternion.identity);
        } else
        {
            Debug.Log("No instancia un drop");
        }


        //Se necesita pulir codigo para animacion antes de morir
        Destroy(this.gameObject);
    }

    void MovementController()
    {
        Findtarget();

        if (tp)
        {
            StartCoroutine(TeleportNext());
        }

        if (playerDetected && spawn)
        {
            StartCoroutine(SpawnEnemy());
        }
        
    }

    IEnumerator TeleportNext()
    {
        tp = false;
        TeleportToLocations();
        yield return tpCoolDown;
        tp = true;
    }

    IEnumerator SpawnEnemy()
    {
        spawn = false;
        SpawnToPlayer();
        yield return spawnCoolDown;
        spawn = true;
    }

    void SpawnToPlayer()
    {
        /*Vector3 playerLocationCorrected = new Vector3(playerLocation.position.x, this.transform.position.y, playerLocation.position.z);
        transform.position = Vector3.MoveTowards(transform.position, playerLocationCorrected, speed * Time.deltaTime);*/
        Debug.Log("Aparece un enemigo");
    }

    void TeleportToLocations()
    {
        /*Vector3 locationsCorrected = new Vector3(locations[chosen].x, this.transform.position.y, locations[chosen].z);
        locations[chosen] = locationsCorrected;*/

        //transform.position = Vector3.MoveTowards(transform.position, locations[chosen], speed * Time.deltaTime);
        transform.position = locations[chosen];
        Vector3 position = gameObject.transform.position;
        if (position == locations[chosen])
        {
            chosen = chosen + plusminus;
        }
        if (chosen == (locations.Length - 1))
        {
            plusminus = -1;
        }
        if (chosen == 0)
        {
            plusminus = 1;
        }
        /*if (transform.position.x < locations[chosen].x)
        {
            //SIRVE PARA DAR PERSPECTIVA 2D A UN OBJETO 3D
            //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -0.25f);
        }
        else
        {
            //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 0.25f);
        }*/
    }
   /* private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            speed = 0.0f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            speed = 2.0f;
        }
    }*/
}
