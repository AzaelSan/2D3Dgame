using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sounds
{
    jump,
    death,
    attack,
    reciveDamage,
    backgroundMusic
}

public class AudioManager : MonoBehaviour
{
    static AudioManager instance;
    public float masterVolume;

    [Header("SFX")]
    public AudioClip jump;
    public AudioClip death;
    public AudioClip attack;
    public AudioClip reciveDamage;

    [Header("Music")]
    public AudioClip backgroundMusic;

    [HideInInspector]
    public AudioSource audioManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioManager = GetComponent<AudioSource>();
        //audioManager.PlayOneShot(backgroundMusic);
    }

    public void playSound(Sounds _soundName)
    {
        switch(_soundName)
        {
            case Sounds.jump:
                audioManager.PlayOneShot(jump);
                break;
            case Sounds.death:
                audioManager.PlayOneShot(death);
                break;
            case Sounds.attack:
                audioManager.PlayOneShot(attack);
                break;
            case Sounds.reciveDamage:
                audioManager.PlayOneShot(reciveDamage);
                break;
        }
        
    }
}
