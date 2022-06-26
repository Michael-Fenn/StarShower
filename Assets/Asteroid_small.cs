using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_small : MonoBehaviour
{
    public enemy_spawn ship_spawner;
    public GameObject game_area;
    public float speed;


    void Update()
    {
        Move();
    }

    void Move(){
        transform.position += transform.up * (Time.deltaTime * speed);

        float distance = Vector3.Distance(transform.position, game_area.transform.position);
        if(distance > ship_spawner.death_circle_radius){
            RemoveShip();
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "friendly_projectile(Clone)"){
         score_script.scoreValue += 50;
         Destroy(col.gameObject);
         Destroy(gameObject);  
        }
        else if(col.gameObject.name == "shipconcept"){
            Destroy(gameObject);
            Health hp = col.gameObject.GetComponent<Health>();
            hp.health -= 1; 
        }
    }
    void RemoveShip(){
        Destroy(gameObject);
    }
   
    
}
