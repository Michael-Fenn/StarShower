using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numHearts;

    public Image[] hearts;
    public Sprite heart;

    public GameOverScript GameOverScript;

    void Update(){

        numHearts = health;      

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < numHearts){
                hearts[i].enabled = true;        
            }
            else{
                hearts[i].enabled = false;
            }
        }

        if (numHearts <= 0){
            Destroy(GameObject.FindWithTag("Player"));
            GameOverScript.Setup(score_script.scoreValue);
        }
    }
}
