﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private AudioClip coinSound;



    private Rigidbody rig;
    private AudioSource audioSource;

    private bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.paused)
        {
            return;
        }
        
        Move();

        if (Input.GetButtonDown("Jump"))
        {
            TryJump();
        }
        
        if (rig.velocity.y >= 5f)
        {
            rig.velocity = Vector3.zero;
            rig.AddForce(Vector3.up * jumpForce);
        }
    }

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Move()
    {
        //Getting our inputs
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        
        Vector3 dir = new Vector3(xInput, 0, zInput) * moveSpeed;
        dir.y = rig.velocity.y;

        rig.velocity = dir;
        
        Vector3 facingDir = new Vector3(xInput, 0, zInput);

        if (facingDir.magnitude > 0)  {
            transform.forward = facingDir;
        }
}

    void TryJump()
    {
        Ray ray1 = new Ray(transform.position + new Vector3(0.5f, 0, 0.5f), Vector3.down);
        Ray ray2 = new Ray(transform.position + new Vector3(-0.5f, 0, 0.5f), Vector3.down);
        Ray ray3 = new Ray(transform.position + new Vector3(0.5f, 0, -0.5f), Vector3.down);
        Ray ray4 = new Ray(transform.position + new Vector3(-0.5f, 0, -0.5f), Vector3.down);
        Ray ray5 = new Ray(transform.position + new Vector3(0f, 0, 0f), Vector3.down);

        bool raycast1 = Physics.Raycast(ray1, 0.7f);
        bool raycast2 = Physics.Raycast(ray2, 0.7f);
        bool raycast3 = Physics.Raycast(ray3, 0.7f);
        bool raycast4 = Physics.Raycast(ray4, 0.7f);
        bool raycast5 = Physics.Raycast(ray5, 0.5f);

        if (raycast1 || raycast2 || raycast3 || raycast4 || raycast5)
        {
            if (isGrounded)
            { 
               rig.velocity = Vector3.zero;
               rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
               isGrounded = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameManager.instance.GameOver();
        }
        
        if (other.tag == "Coin")
        {
            audioSource.PlayOneShot(coinSound);
            Destroy(other.gameObject);
            GameManager.instance.AddScore(1);
        }

        if (other.tag == "End")
        {
            GameManager.instance.LevelEnd();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isGrounded = true;
    }
}
