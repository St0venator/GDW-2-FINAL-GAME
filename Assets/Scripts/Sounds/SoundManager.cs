using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioSource jumpSFX, shootSFX, swordSFX;


    public void PlayJumpSound()
    {
        jumpSFX.Play();
    }
    public void PlayShootSFX()
    {
        shootSFX.Play();
    }
    public void PlaySwordSFX()
    {
        swordSFX.Play();
    }



}
