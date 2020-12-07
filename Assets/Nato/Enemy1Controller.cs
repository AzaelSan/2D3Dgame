using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Controller : MonoBehaviour
{
    Transform playerLocation;
    public Vector3[] locations;
    public float speed;
    public int chosen;
    public int plusminus;
    public bool playerDetected;
    public GameObject[] drops;
    public float stun;

    float targetRange = 5f;
    float recurrentSpeed;

    private EnemyBase enemyBase;

    private void Awake()
    {

    }

    void Start()
    {
        recurrentSpeed = speed;
        enemyBase = this.GetComponent<EnemyBase>();
        //enemyBase.enemyType = EnemyController.EnemyType.ENEMY1;
        enemyBase.currentHealth = enemyBase.maxHealth;
        playerDetected = false;
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
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
        if(probDrop >= 50)
        {
            Debug.Log("Instancia un drop");
            probDrop = Random.Range(0, drops.Length);
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
        if (playerDetected)
        {
            FollowPlayer();
        }
        else
        {
            MoveLocations();
        }
    }

    void FollowPlayer()
    {
        Vector3 playerLocationCorrected = new Vector3(playerLocation.position.x, this.transform.position.y, playerLocation.position.z);
        transform.position = Vector3.MoveTowards(transform.position, playerLocationCorrected, speed * Time.deltaTime);
    }

    void MoveLocations()
    {
        Vector3 locationsCorrected = new Vector3(locations[chosen].x, this.transform.position.y, locations[chosen].z);
        locations[chosen] = locationsCorrected;

        transform.position = Vector3.MoveTowards(transform.position, locations[chosen], speed * Time.deltaTime);
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
        if (transform.position.x < locations[chosen].x)
        {
            //SIRVE PARA DAR PERSPECTIVA 2D A UN OBJETO 3D
            //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -0.25f);
        }
        else
        {
            //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 0.25f);
        }
    }

    public void Stunned()
    {
        Debug.Log("Entro en Stunned");
        speed = 0;
        StartCoroutine(MoveAgain());
    }

    IEnumerator MoveAgain()
    {
        yield return new WaitForSeconds(stun);
        speed = recurrentSpeed;
        Debug.Log("Entro en MoveAgain");
    }
}
