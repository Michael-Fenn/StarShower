using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    void Start (){
      highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI highScore;
    public void Setup(int score){
    gameObject.SetActive(true);
    pointsText.text = "Points: " + score.ToString();
    if (score > PlayerPrefs.GetInt("HighScore", 0)){
      PlayerPrefs.SetInt("HighScore", score);
    }
     
   }
   public void RestartButton(){
        SceneManager.LoadScene("Game");
   }
   public void ExitButton(){
         SceneManager.LoadScene("Menu");
   }
}
