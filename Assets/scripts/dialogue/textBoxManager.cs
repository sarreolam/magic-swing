using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class textBoxManager : MonoBehaviour
{
    public GameObject textBox;
    public TextMeshProUGUI theText;
    public TextMeshProUGUI theSpeaker;

    public Player player;
    public EnemySpawner enemySpawner;
    public EnemyUpSpawner enemyUpSpawner;
    public GameObject boss;
    public TextAsset textFile;
    public string[] textLines;
    
    public int currentLine;
    public int endAtLine;

    public bool isActive;
    bool gameStart = false;
    

    //public PlayerController player;

    void Start()
    {
        //player = FindObjectOfType<PlayerController>;
        player = FindObjectOfType<Player>();

        if (textFile != null){
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0){
            endAtLine = textLines.Length - 1;
        }        

        if(isActive){
            EnableTextBox();
        } else {
            DisableTextBox();
        }
    
    }

    void Update()
    {
        if(!isActive){
            return;
        }

        theSpeaker.text = textLines[currentLine];
        theText.text = textLines[currentLine+1];
        if (Input.GetKeyDown(KeyCode.Space) && currentLine < endAtLine){
            currentLine += 2;
        }

        if(currentLine == endAtLine){
            DisableTextBox();
        }
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;

    }

    public void EnableTextBox(int currentLine, int endAtLine)
    {
        textBox.SetActive(true);
        isActive = true;
        this.currentLine = currentLine;
        this.endAtLine = endAtLine;
        
    }

    public void DisableTextBox(){
        textBox.SetActive(false);
        isActive = false;
        player.CallMoveToCenter(!gameStart);
        currentLine = 0;


        if (boss != null)
        { 
            boss.GetComponent<BossMovement>().SetPlayerIsMoving(true);
        }
    }

    public void ReloadScript(TextAsset theText){
        if(theText != null){
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }

    public void SetGameStart(bool gameStart)
    {
        this.gameStart = gameStart;
    }



}
