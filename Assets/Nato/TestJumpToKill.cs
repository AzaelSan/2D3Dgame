using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJumpToKill : MonoBehaviour
{
    public static TestJumpToKill Instance { get; private set; }
    public int health = 3;
    public bool vulnerable = true;
    WaitForSeconds invulneravility = new WaitForSeconds(1f);
    public int damageOfPlayer = 1;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyBase>().TakeDamage(damageOfPlayer);
        }
    }

    public void TakeDamage(int damage)
    {
        if (vulnerable)
        {
            StartCoroutine(GetDamage(damage));
        }
    }

    IEnumerator GetDamage(int damage)
    {
        health -= damage;
        vulnerable = false;
        yield return invulneravility;
        vulnerable = true;
    }
}
