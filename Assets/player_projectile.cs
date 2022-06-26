using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_projectile : MonoBehaviour
{
    private float Speed = 20f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.up * Time.deltaTime * Speed;
        Object.Destroy(gameObject, 2.0f);
        
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Destroy(gameObject);
    //     Destroy(collision.gameObject);
    // }
    
}
