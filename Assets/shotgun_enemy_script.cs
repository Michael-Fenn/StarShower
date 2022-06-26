using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgun_enemy_script : MonoBehaviour
{
       public float speed = 4f;

    private GameObject player;
    private Transform playerTransform;
    private Rigidbody2D rb;
    private Vector2 movement;
    public enemy_spawn ship_spawner;
    bool playerInRange;
    public float fireRate;
    float nextFire;
    public AudioSource projectile_sound;
    int hp_powerup = 1;
    int shot_powerup = 2;
    public GameObject hp_power;
    public GameObject shot_power;

    [SerializeField]
    GameObject enemy_projectile;

    void Start(){
        fireRate = 5f;
        nextFire = Time.time;
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        projectile_sound = GetComponent<AudioSource>();
    }

    void Update(){
        if (playerInRange){
            attack();
        }
        else if (playerTransform != null){
            Vector3 direction = playerTransform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 90f;
            direction.Normalize();
            movement = direction;
        }
    }

    private void FixedUpdate(){
        //if (playerInRange == false)
            moveCharacter(movement);
        if (playerInRange == true){
            Vector3 direction = playerTransform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle - 70f;
            direction.Normalize();
            movement = direction;
        }
    }

    void moveCharacter(Vector2 direction){

        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

void attack(){
    if(Time.time > nextFire){
        Vector3 direction = playerTransform.position-transform.position;
        direction .Normalize();
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Instantiate(enemy_projectile, transform.position, Quaternion.Euler(0f, 0f, rotation - 60));
        Instantiate(enemy_projectile, transform.position, Quaternion.Euler(0f, 0f, rotation - 90));
        Instantiate(enemy_projectile, transform.position, Quaternion.Euler(0f, 0f, rotation - 120));
        nextFire = Time.time + fireRate;
        projectile_sound.Play();
    }
}
void OnCollisionEnter2D(Collision2D col){
    Debug.Log("collision");
    if(col.gameObject.name == "friendly_projectile(Clone)"){
         score_script.scoreValue += 200;
         Destroy(col.gameObject);
         Destroy(gameObject);  
         ship_spawner.shotgun_count -= 1;
        if (Random.Range(0,20)==hp_powerup){
            Instantiate(hp_power, transform.position, Quaternion.identity);
        }
        else if(Random.Range(0,20)==shot_powerup){
            Instantiate(shot_power, transform.position, Quaternion.identity);
        }

}
}
 void OnTriggerEnter2D(Collider2D other)
 {
    if(other.tag == "Player")
       playerInRange = true;
      // Debug.Log("in range");
    
 }
 void OnTriggerExit2D(Collider2D other){
     if(other.tag == "Player")
        playerInRange = false;
        //Debug.Log("not in range");
 }
}
