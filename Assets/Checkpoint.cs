using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameManager gm;
    public int level;
    public UI_gameplay gempley;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gm.lastCheckpointPos = transform.position;
            gm.health = other.gameObject.GetComponent<PlayerCombat>().Health;
            gm.currentLevel = level;
            SaveSystem.SaveData(gm);
            StartCoroutine(gempley.SetCheckpointText());
        }
    }
}
