using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRetrieve : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Asume que tienes un Text en la escena para mostrar el puntaje

    void Start()
    {
        // Recupera el puntaje guardado
        int playerScore = PlayerPrefs.GetInt("PlayerScore", 0); // 0 es el valor por defecto si no hay ningún puntaje guardado

        // Muestra el puntaje en el Text (si tienes un UI Text en la escena)
        if (scoreText != null)
        {
            scoreText.text = playerScore.ToString();
        }
    }
}
