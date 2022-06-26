using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgun_powreup : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            player_movement1 shotgun = col.gameObject.GetComponent<player_movement1>();
            shotgun.shot_powerup = true;
            Destroy(gameObject);
        }
        Destroy(gameObject, 5);
        }
    // private void shotgun(){
    //     for(int i=0; i <= 2; i++){
    //         var spawnedBullet = Instantiate(bullet, fireOffset.position, fireOffset.rotation);

    //         switch (i)
    //         {
    //             case 0:
    //                 spawnedBullet.AddForce(fireOffset.up * speed + new Vector3(0f, -90f, 0f));
    //                 break;
    //             case 1:
    //                 spawnedBullet.AddForce(fireOffset.up * speed + new Vector3(0f, 0f, 0f));
    //                 break;
    //             case 2:
    //                 spawnedBullet.AddForce(fireOffset.up * speed + new Vector3(0f, 90f, 0f));
    //                 break;
    //         }
    //     }
    // }
}
