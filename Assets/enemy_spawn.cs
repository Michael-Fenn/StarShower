using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
    public GameObject game_area;
    public GameObject ship_prefab;
    public GameObject distance_enemy;
    public GameObject shotgun_enemy;

    public int ship_count = 0;
    public int distance_count = 0;
    public int distance_limit = 5;
    public int shotgun_count = 0;
    public int shotgun_limit = 5;
    public int ship_limit = 10;
    public int ships_per_frame = 1;

    public float spawn_circle_radius = 150.0f;
    public float death_circle_radius = 160.0f;

    public float fastest_speed = 10.0f;
    public float slowest_speed = 1.0f;

    
    void Update()
    {
        MaintainPopulation();
    }

    void MaintainPopulation(){
        if(ship_count < ship_limit){
            for(int i = 0; i < ships_per_frame; i++){
                Vector3 position = GetRandomPosition();
                Asteroid asteroid_script = AddShip(position);
                asteroid_script.transform.Rotate(Vector3.forward * Random.Range(-35.0f, 35.0f));
            }
        }
        if(distance_count < distance_limit){
            for(int i = 0; i < ships_per_frame; i++){
                Vector3 position = GetRandomPosition();
                distance_enemy dEnemy_script = addDistanceShip(position);
            }
        }
         if(shotgun_count < shotgun_limit){
            for(int i = 0; i < ships_per_frame; i++){
                Vector3 position = GetRandomPosition();
                shotgun_enemy_script sEnemy_script = addShotgunShip(position);
            }
        }

    }

    Vector3 GetRandomPosition(){
        Vector3 position = Random.insideUnitCircle.normalized;

        position *= spawn_circle_radius;
        position += game_area.transform.position;

        return position;
    }

    Asteroid AddShip(Vector3 position){
        ship_count+=1;
        GameObject new_ship = Instantiate(
            ship_prefab,
            position,
            Quaternion.FromToRotation(Vector3.up, (game_area.transform.position-position)),
            gameObject.transform
        );
        Asteroid asteroid_script = new_ship.GetComponent<Asteroid>();
        asteroid_script.ship_spawner = this;
        asteroid_script.game_area = game_area;
        asteroid_script.speed = Random.Range(slowest_speed, fastest_speed);

        return asteroid_script;
    }
    distance_enemy addDistanceShip(Vector3 position){
        distance_count += 1;
        GameObject new_ship = Instantiate(
            distance_enemy,
            position,
            Quaternion.FromToRotation(Vector3.down, (game_area.transform.position-position)),
            gameObject.transform
        );
        distance_enemy enemy_script = new_ship.GetComponent<distance_enemy>();
        enemy_script.ship_spawner = this;
        enemy_script.speed = 5.5f;
        return enemy_script;
    }
    shotgun_enemy_script addShotgunShip(Vector3 position){
        shotgun_count += 1;
        GameObject new_ship = Instantiate(
            shotgun_enemy,
            position,
            Quaternion.FromToRotation(Vector3.down, (game_area.transform.position-position)),
            gameObject.transform
        );
        shotgun_enemy_script enemy_script = new_ship.GetComponent<shotgun_enemy_script>();
        enemy_script.ship_spawner = this;
        enemy_script.speed = 3f;
        return enemy_script;
    }

}
