using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private float bobSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float bobHeight;

    private Vector3 startPos;
    private Vector3 targetPos;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + new Vector3(0, bobHeight, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, bobSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up,  rotateSpeed * Time.deltaTime, Space.World);

        if (transform.position == targetPos)
        {
            if (targetPos == startPos)
            {
                targetPos = startPos + new Vector3(0, bobHeight, 0);
            } else if (targetPos == startPos + new Vector3(0, bobHeight, 0))
            {
                targetPos = startPos;
            }
        }
    }
}
