using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


/// Administra los cuadros de texto que muestran diálogo en pantalla, incluyendo el texto del diálogo y el hablante.

public class textBoxManager : MonoBehaviour
{
    public GameObject textBox;
    public TextMeshProUGUI theText;
    public TextMeshProUGUI theSpeaker;

    public TextAsset textFile;
    public string   [] textLines;

    public Timeline timeline;
    
    public int currentLine;
    public int endAtLine;

    public bool isActive;


    void Start()
    {
        // Carga las líneas del archivo de texto en el arreglo si está disponible.
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
        // Si no se define un valor para `endAtLine`, se usa la última línea del archivo.

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
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

        if(currentLine >= endAtLine){
            DisableTextBox();
        }
    }

    /// Activa el cuadro de texto y permite mostrar diálogos.
    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;

    }
    /// Activa el cuadro de texto, especificando las líneas de inicio y fin.
    /// <param name="currentLine">Línea inicial.</param>
    /// <param name="endAtLine">Línea final.</param>
    public void EnableTextBox(int currentLine, int endAtLine)
    {
        this.currentLine = currentLine;
        this.endAtLine = endAtLine;
        textBox.SetActive(true);
        isActive = true;
        
    }
    /// Desactiva el cuadro de texto y avanza en la línea de tiempo del juego.
    public void DisableTextBox(){
        textBox.SetActive(false);
        isActive = false;
        timeline.Next();

    }
    /// Recarga un nuevo archivo de texto para cambiar los diálogos.
    /// <param name="theText">Archivo de texto con los nuevos diálogos.</param>
    public void ReloadScript(TextAsset theText){
        if(theText != null){
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }

    //public void SetGameStart(bool gameStart)
    //{
    //    this.gameStart = gameStart;
    //}



}
