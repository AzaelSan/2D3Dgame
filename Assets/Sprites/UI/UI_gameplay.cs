using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_gameplay : MonoBehaviour
{
    PlayerCombat player;

    public GameObject time;
    public int seconds;

    public GameObject saving;
    public Image hearth_1, hearth_2, hearth_3;

    public Sprite hearth_empty;
    public Sprite hearth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        time.GetComponent<TMPro.TextMeshProUGUI>().text = seconds.ToString();
        StartCoroutine(Counter());
    }

    public void SetHearths()
    {
        if(player.Health == 3)
        {
            hearth_1.sprite = hearth;
            hearth_2.sprite = hearth;
            hearth_3.sprite = hearth;
        }
        else if (player.Health == 2)
        {
            hearth_1.sprite = hearth_empty;
            hearth_2.sprite = hearth;
            hearth_3.sprite = hearth;
        }
        else if (player.Health == 1)
        {
            hearth_1.sprite = hearth_empty;
            hearth_2.sprite = hearth_empty;
            hearth_3.sprite = hearth;
        }
        else if (player.Health == 0)
        {
            hearth_1.sprite = hearth_empty;
            hearth_2.sprite = hearth_empty;
            hearth_3.sprite = hearth_empty;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            StartCoroutine(SetCheckpointText());
        }
    }

    //Restar tiempo
    IEnumerator Counter()
    {
        while (seconds > 0)
        {
            yield return new WaitForSecondsRealtime(1.0f);
            seconds -= 1;
            if (seconds >= 100)
            {
                time.GetComponent<TMPro.TextMeshProUGUI>().text = seconds.ToString();
            }
            else if(seconds < 100 && seconds >= 10)
            {
                time.GetComponent<TMPro.TextMeshProUGUI>().text = "0" + seconds.ToString();
            }
            else if(seconds < 10)
            {
                time.GetComponent<TMPro.TextMeshProUGUI>().text = "00" + seconds.ToString();
            }
        }
        //Perder si se acaba el tiempo
        PlayerCombat.gameover = true;
    }

    IEnumerator SetCheckpointText()
    {
        saving.SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        saving.SetActive(false);
    }
}
