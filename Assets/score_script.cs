using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class score_script : MonoBehaviour
{
    public static int scoreValue = 0;
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
      score = GetComponent<TextMeshProUGUI> (); 
      scoreValue = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        score.text = "Score: " + scoreValue;
    }

    
}
