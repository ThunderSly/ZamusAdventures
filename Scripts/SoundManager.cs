using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static AudioClip playerHitSound, fireSound, enemyDeathSound, jumpSound, enemyHitSound, gameOverSound, powerUpSound, gateOpenSound;
    static AudioSource audioSource;

    void Start () {

        playerHitSound = Resources.Load<AudioClip> ("playerHit");
        fireSound = Resources.Load<AudioClip> ("fireSound");
        enemyDeathSound = Resources.Load<AudioClip> ("enemyDeath");
        jumpSound = Resources.Load<AudioClip> ("jumpSound");
        enemyHitSound = Resources.Load<AudioClip> ("enemyHit");
        gameOverSound = Resources.Load<AudioClip> ("gameOver");
        powerUpSound = Resources.Load<AudioClip> ("powerUp");
        gateOpenSound = Resources.Load<AudioClip> ("gateOpen");
        audioSource = GetComponent<AudioSource> ();

    }
    
    void Update () {

    }

    public static void PlaySound (string clip){
        switch (clip)
        {
            
            case "playerHit":
                audioSource.PlayOneShot(playerHitSound);
                break;

            case "fireLaser":
                audioSource.PlayOneShot(fireSound);
                break;

            case "enemyDeath":
                audioSource.PlayOneShot(enemyDeathSound);
                break;

            case "jumpSound":
                audioSource.PlayOneShot(jumpSound);
                break;

            case "enemyHit":
                audioSource.PlayOneShot(enemyHitSound);
                break;

            case "gameOver":
                audioSource.PlayOneShot(gameOverSound);
                break;

            case "powerUp":
                audioSource.PlayOneShot(powerUpSound);
                break;

            case "gateOpen":
                audioSource.PlayOneShot(gateOpenSound);
                break;                
        }
    }
}