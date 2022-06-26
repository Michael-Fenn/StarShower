using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_projectile : MonoBehaviour
{
   private float speed = 5f;
    Rigidbody2D rb;
    Player target;
    Vector2 moveDirection;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player>();
        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
        Destroy(gameObject, 3f);
    }
    void FixedUpdate(){
        transform.position += transform.up * Time.deltaTime * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            Destroy(gameObject);
            Health hp = collision.gameObject.GetComponent<Health>();
            hp.health -= 1; 
        
        }
        
    }
}
