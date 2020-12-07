using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public EnemyController controller;
    public int maxHealth;
    public int currentHealth;
    public int damageOfEnemy;
    public Rigidbody rigi;
    public EnemyType enemyType;

    public void Start()
    {
        maxHealth = controller.SetHealth(enemyType);
        currentHealth = maxHealth;
        controller.SetDamage(enemyType, damageOfEnemy);
        rigi = GetComponent<Rigidbody>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void Empujar(Vector3 PlayerPos)
    {
        Vector3 dir = transform.position - PlayerPos;
        dir.Normalize();
        rigi.AddForce(dir * 5f, ForceMode.Impulse);
        rigi.AddForce(Vector3.up * 5f, ForceMode.Impulse);
    }
}
