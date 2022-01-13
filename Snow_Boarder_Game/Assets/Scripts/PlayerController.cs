using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 3f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    public bool death = false;
     
    
    Rigidbody2D rb2d;
    private SurfaceEffector2D surfaceEffector2D;
    
    private void Start()
    { 
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>(); 
    }

    private void Update()
    {
        if (!death)
        {
            RotatePlayer();
            RespondToBoost();
        }
        else
        {
            float deathSpeed = UnityEngine.Random.Range(-2f, 2f);
            surfaceEffector2D.speed = deathSpeed;
        }
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.Space) && !death)
        { 
            surfaceEffector2D.speed = boostSpeed;
        }else
        { 
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(
                torqueAmount); // torque es una fuerza para rotar el objeto, en este caso lo rotamos hacia la izquierda
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}
