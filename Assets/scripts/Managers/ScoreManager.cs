using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int currentScore = 0;
    public TextMeshProUGUI scoreTextMesh;

    void Start(){
        UpdateScoreDisplay();
    }

    public void IncreaseScore(){
        currentScore += 50;
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay(){
        scoreTextMesh.text = currentScore.ToString();
    }
}
