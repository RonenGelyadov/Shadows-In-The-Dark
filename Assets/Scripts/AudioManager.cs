using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioSource gunshot;
    public AudioSource footsteps;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        soundPlayer();
    }

    void soundPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gunshot.Play();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            footsteps.Play();
        }
        else
        {
            footsteps.Pause();
        }
    }
}
