using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI myScoreText;
    int scoreNumber;
    // Start is called before the first frame update
    void Start()
    {
        scoreNumber = 0;
        myScoreText.text = "Score : " + scoreNumber;
    }

  
}
