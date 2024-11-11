using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void Restart() {
        SceneManager.LoadScene("Menu");
    }
    public void StartGame() {
        SceneManager.LoadScene("Level1");
    }
    public void GameOver(){
        SceneManager.LoadScene("Lose");
    }
}
