using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOutOfBound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Vector3 respawnPos = new Vector3(0, 0.63f, 0);
            other.transform.position = respawnPos;
        }
    }
}
