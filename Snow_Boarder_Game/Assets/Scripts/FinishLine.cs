using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] ParticleSystem finishEffect;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        { 
            finishEffect.Play(); 
            Invoke("ReloadScene", 2f); // esperamos 2 segundos para cargar la siguiente escena
        }
    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
