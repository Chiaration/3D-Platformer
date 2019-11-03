using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody rig;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
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

        if (facingDir.magnitude > 0)
        {
            transform.forward = facingDir;
        }
    }
}
