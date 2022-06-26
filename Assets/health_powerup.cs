using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_powerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Player")){
            Health hp = col.gameObject.GetComponent<Health>();
            hp.health += 1; 

            Destroy(gameObject);
        }
        Destroy(gameObject, 5);
        }
    }
  
