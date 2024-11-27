using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int currentScore = 0;
    public TextMeshProUGUI scoreTextMesh;

    void Start()
    {
        // Verificar el nombre de la escena actual
        string currentScene = SceneManager.GetActiveScene().name;

        // Si no estamos en Level1, cargar el puntaje guardado
        if (currentScene != "Level1")
        {
            currentScore = PlayerPrefs.GetInt("PlayerScore", 0); // Carga el puntaje guardado si no estamos en Level1
        }
        else
        {
            ResetScore(); // Si estamos en Level1, reiniciar el puntaje
        }

        UpdateScoreDisplay();
    }

    public void IncreaseScore()
    {
        currentScore += 50;
        PlayerPrefs.SetInt("PlayerScore", currentScore); // Guarda el puntaje actual
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        scoreTextMesh.text = currentScore.ToString();
    }

    public void ResetScore()
    {
        currentScore = 0;
        PlayerPrefs.SetInt("PlayerScore", currentScore); // Guarda el nuevo puntaje
        UpdateScoreDisplay();
    }
}