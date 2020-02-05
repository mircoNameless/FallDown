using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    
    public float speed;
    private Vector3 movement;
    private float deadLine;
    
    private void Start()
    {
        movement.y = speed;
        deadLine = GameMgr.instance.topLine.position.y;
    }
    
    private void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        transform.position += movement * Time.deltaTime;
        if (transform.position.y >= deadLine)
        {
            Destroy(gameObject);
        }
    }
}
