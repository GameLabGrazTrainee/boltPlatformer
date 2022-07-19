using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private int direction = 1;  

    // Update is called once per frame
    void Update()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }  

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("EnemyPoint"))
        {
            direction *= -1;
        }
    }



   

    
}
