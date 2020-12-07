using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletUp;
    public GameObject bulletDown;
    public GameObject bulletLeft;
    public GameObject bulletRight;

    public float shootCooldown = 3f;

    public bool canShoot = true;
    public bool up;
    public bool down;
    public bool left;
    public bool right;

    // Update is called once per frame
    void Update()
    {
        if(canShoot)
        {
            StartCoroutine(SpawnBullet());
        }

    }

    IEnumerator SpawnBullet()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldown);
        if(up)
        {
            Instantiate(bulletUp, transform.position, transform.rotation);
        }
        if (down)
        {
            Instantiate(bulletDown, transform.position, transform.rotation);
        }
        if (right)
        {
            Instantiate(bulletRight, transform.position, transform.rotation);
        }
        if (left)
        {
            Instantiate(bulletLeft, transform.position, transform.rotation);
        }
        canShoot = true;

    }
}
