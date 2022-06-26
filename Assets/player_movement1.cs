using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement1 : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D ProjectilePrefab;
    public Transform LaunchOffset;
    public AudioSource projectile_sound;
    public bool shot_powerup;
    // Start is called before the first frame update
    void Start(){
        shot_powerup = false;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector2 pos = transform.position;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, direction);
        transform.eulerAngles = new Vector3 (0, 0, angle);

        pos.x += h * speed * Time.deltaTime;
        pos.y += v * speed * Time.deltaTime;

        transform.position = pos;

        if (Input.GetButtonDown("Fire1"))
        {
            projectile_sound.Play();
            if(shot_powerup == false)
                Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
            else if(shot_powerup){
                shotgun();
                Invoke("boolChange", 5);
            }
            
        }
    }
      private void boolChange(){
        shot_powerup = false;
      }
    private void shotgun(){
        float projspeed = 20f;
        for(int i=0; i <= 2; i++){
            var spawnedBullet = Instantiate(ProjectilePrefab, LaunchOffset.position, LaunchOffset.rotation);

            switch (i)
            {
                
                case 0:
                    spawnedBullet.transform.Rotate(0,0,30);
                    spawnedBullet.AddForce(LaunchOffset.up * projspeed * Time.deltaTime + new Vector3(0f, -90f, -50f));
                    break;
                case 1:
                    spawnedBullet.AddForce(LaunchOffset.up * projspeed + new Vector3(0f, 0f, 0f));
                    break;
                case 2:
                    spawnedBullet.transform.Rotate(0,0,-30);
                    spawnedBullet.AddForce(LaunchOffset.up * projspeed * Time.deltaTime + new Vector3(0f, 90f, 50f));
                    break;
            }
        }
    }
  
}
