﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Vector3 aplastar = new Vector3(0, -1, 0);
    private Rigidbody rigi;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 1f;
    public LayerMask enemyLayers;
    public int attackDamage = 1;
    private AudioSource playerAudio;
    public AudioClip golpe;
    public AudioClip dano;
    public AudioClip aplastarSFX;
    //public EnemyController controller;
    GameManager gm;

    [Header("Estadisticas")]
    public int Health;
    public float TimeOfInvulnerability;
    public float TimeUntilNextAttack;

    bool canAttack = true;//Para esperar entre cada ataque
    bool invulnerable = false;//Para hacer inmune al jugador por unos segundos despues de ser golpeado
    public static bool gameover = false;

    private UI_gameplay ui;
    private AudioManager audioManager;

    private void Start()
    {
        gameover = false;
        GameManager.instance.gameOver = gameover;
        GameManager.instance.win = false;
        playerAudio = GetComponent<AudioSource>();
        SettingsMenu.mainMenu = false;
        ui = GameObject.FindGameObjectWithTag("UI_gameplay").GetComponent<UI_gameplay>();
        //audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        rigi = GetComponent<Rigidbody>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        transform.position = gm.lastCheckpointPos;
    }

    void Update()
    {
        if (!gameover)
        {
            if ((Input.GetButtonDown("Button X") || Input.GetKeyDown(KeyCode.L)) && canAttack)
            {
                Attack();
                //audioManager.playSound(Sounds.attack);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !invulnerable)
        {

            if (Physics.OverlapSphere(aplastar + transform.position, 0.2f, enemyLayers).Length > 0)
            {
                playerAudio.clip = aplastarSFX;
                playerAudio.Play();
                rigi.AddRelativeForce(Vector3.up * 15.0f, ForceMode.Impulse);
                collision.gameObject.GetComponent<EnemyBase>().TakeDamage(1);
                collision.gameObject.GetComponent<Enemy1Controller>().Stunned();
            }
            else
            {
                playerAudio.clip = dano;
                playerAudio.Play();
                takeDamage(collision.GetContact(0).normal);
                collision.gameObject.GetComponent<Enemy1Controller>().Stunned();
            }
        }
        if (collision.gameObject.CompareTag("Death zone"))
        {
            gameover = true;
            GameManager.instance.gameOver = gameover;
            GameManager.instance.GameOver();
        }
    }

    void Attack()
    {
        ///Play Sound
        playerAudio.clip = golpe;
        playerAudio.Play();
        ///Play animation
        //animator.SetTrigger("Attack");
        ///Detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        ///Deal damage
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyBase>().TakeDamage(attackDamage); //Hacer daño al enemigo
            enemy.GetComponent<EnemyBase>().Empujar(transform.position); //Empujar al enemigo hacia atras
            enemy.GetComponent<Enemy1Controller>().Stunned();
        }
        StartCoroutine(waitToAttack());
    }

    public void takeDamage(Vector3 _direction)
    {
        Health -= 1;
        ui.SetHearths();
        if (Health <= 0)
        {
            gameover = true;
            GameManager.instance.gameOver = gameover;
            GameManager.instance.GameOver();
        }
        rigi.AddForce(_direction * 10.0f, ForceMode.Impulse); //Impulsar al jugador hacia atras cuando recibe daño
        rigi.AddRelativeForce(Vector3.up * 10.0f, ForceMode.Impulse);
        StartCoroutine(waitToTakeDamage());
    }

    //Esperar para volver a tomar daño
    IEnumerator waitToTakeDamage()
    {
        invulnerable = true;
        yield return new WaitForSeconds(TimeOfInvulnerability);
        invulnerable = false;
    }

    //Esperar para poder volver a atacar
    IEnumerator waitToAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(TimeUntilNextAttack);
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(aplastar + transform.position, 0.2f);
    }

}