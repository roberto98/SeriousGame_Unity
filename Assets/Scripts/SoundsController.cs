using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    public AudioSource winSound;
    public AudioSource loseSound;


    public void PlayWin(){
        winSound.Play();
    }

    public void PlayLose(){
        loseSound.Play();
    }

}
