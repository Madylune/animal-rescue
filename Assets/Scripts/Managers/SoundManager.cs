﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField]
    private AudioSource soundFX;

    [SerializeField]
    private AudioClip landClip, deathClip, iceBreakClip, gameOverClip, flapClip, lootClip, victoryClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ToggleSound(bool toggle)
    {
        //toggle = !toggle;

        AudioListener.volume = toggle ? 1f : 0f;
    }

    public void LandSound()
    {
        soundFX.clip = landClip;
        soundFX.Play();
    }

    public void IceBreakSound()
    {
        soundFX.clip = iceBreakClip;
        soundFX.Play();
    }

    public void DeathSound()
    {
        soundFX.clip = deathClip;
        soundFX.Play();
    }

    public void GameOverSound()
    {
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }

    public void FlapSound()
    {
        soundFX.clip = flapClip;
        soundFX.Play();
    }

    public void LootSound()
    {
        soundFX.clip = lootClip;
        soundFX.Play();
    }

    public void VictorySound()
    {
        soundFX.clip = victoryClip;
        soundFX.Play();
    }
}
