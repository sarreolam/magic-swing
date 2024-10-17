using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateTextAtLine : MonoBehaviour
{
    public TextAsset theText;
    public int startLine;
    public int endLine;

    public textBoxManager textBox;

    public bool destroyWhenActivated;

    void Start()
    {
        textBox = FindObjectOfType<textBoxManager>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.name == "player"){
            textBox.ReloadScript(theText);
            textBox.currentLine = startLine;
            textBox.endAtLine = endLine;
            textBox.EnableTextBox();

            if(destroyWhenActivated){
                Destroy(gameObject);
            }

        }
    }


}
