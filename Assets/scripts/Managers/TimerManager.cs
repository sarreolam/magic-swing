using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public float timeLeft = 180;
    private bool timerOn = false;

    public Player player;

    public TextMeshProUGUI timerTxt;
    private textBoxManager textBoxManager;
    public MenuManager menuManager;

    void Start()
    {
        textBoxManager = FindObjectOfType<textBoxManager>();
        if (timerTxt == null)
        {
            Debug.LogError("timerTxt is not assigned in the editor. Please assign.");
        }
        else
        {
            timerTxt.text = string.Format("{0:00} : {1:00}", Mathf.FloorToInt(timeLeft / 60), Mathf.FloorToInt(timeLeft % 60));
        }
    }

    void Update()
    {
        //if (!timerOn && textBoxManager != null && !textBoxManager.isActive)
        //{
        //    timerOn = true;
        //}

        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                Debug.Log("Time's up!");
                timeLeft = 0;
                timerOn = false;

                StartCoroutine(LoadBoss());
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;
        float min = Mathf.FloorToInt(currentTime / 60);
        float sec = Mathf.FloorToInt(currentTime % 60);

        if (timerTxt != null)
        {
            timerTxt.text = string.Format("{0:00} : {1:00}", min, sec);
        }
        else
        {
            Debug.LogError("timerTxt es null al intentar actualizar el texto. Revisa que el objeto est� activo y asignado.");
        }
    }

    private IEnumerator LoadBoss()
    {
        player.SetGameStart(false);
        player.CallMoveToCenter();
        yield return new WaitForSeconds(3f); // Adjust delay duration as needed
        menuManager.Boss1();
    }
    public void SetTimerOn(bool timerOn)
    {
        this.timerOn = timerOn;
    }
}