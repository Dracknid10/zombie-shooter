using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{

    public AudioSource Moan;
    public AudioSource gunshot;
    public AudioSource reload;


    public void PlayMoan()
    {
        Moan.Play();
    }


    public void Playgunshot()
    {
        gunshot.Play();
    }


    public void Playreload()
    {
        reload.Play();
    }



}
