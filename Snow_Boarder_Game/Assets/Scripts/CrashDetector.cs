using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSound;
    [SerializeField] float loadDelay = 2f;
    [SerializeField] PlayerController player;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {

            if (!player.death)
            {
                crashEffect.Play();
                GetComponent<AudioSource>().PlayOneShot(crashSound);
            }
            
            player.death = true;
            
            Invoke("NextScene", loadDelay);
        }
    }
    
    
    void NextScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
 