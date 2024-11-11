using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class textBoxManager : MonoBehaviour
{
    public GameObject textBox;
    public TextMeshProUGUI theText;
    public TextMeshProUGUI theSpeaker;

    public Player player;
    public EnemySpawner enemySpawner;
    public TextAsset textFile;
    public string[] textLines;
    
    public int currentLine;
    public int endAtLine;

    public bool isActive;
    public bool stopPlayerMovement;

    //public PlayerController player;

    void Start()
    {
        //player = FindObjectOfType<PlayerController>;
        player = FindObjectOfType<Player>();
        enemySpawner = FindObjectOfType<EnemySpawner>();

        if(textFile != null){
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

    public void EnableTextBox(){
        textBox.SetActive(true);
        isActive = true;
        enemySpawner.canSpawn=false;
        if(stopPlayerMovement){
            player.canMove = false;
        }
        
    }

    public void DisableTextBox(){
        textBox.SetActive(false);
        isActive = false;
        enemySpawner.canSpawn=true;
        player.canMove = true;
    }

    public void ReloadScript(TextAsset theText){
        if(theText != null){
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }

}
