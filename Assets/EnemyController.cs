using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    ENEMY1, ENEMY2, ENEMY3
};

public class EnemyController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int SetHealth(EnemyType enemyType)
    {
        int _maxHealth = 0;
        switch (enemyType)
        {
            case EnemyType.ENEMY1:
                _maxHealth = 3;
                break;
            case EnemyType.ENEMY2:
                _maxHealth = 3;
                break;
            case EnemyType.ENEMY3:
                _maxHealth = 2;
                break;
        }
        return _maxHealth;
    }
    public void SetDamage(EnemyType enemyType, int _Damage)
    {
        switch (enemyType)
        {
            case EnemyType.ENEMY1:
                _Damage = 1;
                break;
            case EnemyType.ENEMY2:
                _Damage = 1;
                break;
            case EnemyType.ENEMY3:
                _Damage = 0;
                break;
        }
    }
}
