using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {  
        if(collision.gameObject.name != "distance_shooter_enemy(Clone)")
            Debug.Log("playercol");
            Destroy(collision.gameObject);
            Health hp = gameObject.GetComponent<Health>();
            hp.health -= 1;
    }
    
}
