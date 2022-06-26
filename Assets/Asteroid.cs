using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public enemy_spawn ship_spawner;
    public GameObject game_area;
    public float speed;
    public GameObject split; 
    public Vector2 splitVel1; 
    public Vector2 splitVel2; 
    public Vector2 splitVel3; 
    public Vector2 splitVel4; 

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

    void RemoveShip(){
        Destroy(gameObject);
        ship_spawner.ship_count -= 1;
    }

    void OnTriggerEnter2D(Collider2D col){
         if(col.gameObject.name == "friendly_projectile(Clone)"){
                Vector2 ran = GenRanDirection(); 
                score_script.scoreValue += 100;
                Destroy(col.gameObject);
                Destroy(gameObject);
                GameObject split1 = Instantiate(split, transform.position, Quaternion.Euler(ran));
                GameObject split2 = Instantiate(split, transform.position, Quaternion.Euler(ran));
                GameObject split3 = Instantiate(split, transform.position, Quaternion.Euler(ran));
                GameObject split4 = Instantiate(split, transform.position, Quaternion.Euler(ran));
                split1.GetComponent<Rigidbody2D>().velocity = splitVel1;
                split2.GetComponent<Rigidbody2D>().velocity = splitVel2;
                split3.GetComponent<Rigidbody2D>().velocity = splitVel3;
                split4.GetComponent<Rigidbody2D>().velocity = splitVel4;
                ship_spawner.ship_count -= 1;   

         }
        if(col.gameObject.name == "shipconcept"){
            ship_spawner.ship_count -= 1;
            Health hp = col.gameObject.GetComponent<Health>();
            hp.health -= 1; 
            Destroy(gameObject);
        }
    }
    Vector2 GenRanDirection(){
         return Random.insideUnitCircle.normalized * speed;
    }
   
    
}
