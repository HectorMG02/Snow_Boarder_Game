using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            crashEffect.Play();
            Invoke("NextScene", 2f);
        }
    }
    
    
    void NextScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
 