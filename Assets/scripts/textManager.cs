using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class textManager : MonoBehaviour
{
    TextMeshProUGUI text;
    string fileContent;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();


        string path = Application.dataPath + "/guionPrueba.txt";
        Debug.Log(Application.dataPath + "/guionPrueba.txt");
        // Check if the file exists
        if (File.Exists(path))
        {
            // Read the content of the file
            fileContent = File.ReadAllText(path);

            // Output the content to the console
            Debug.Log(fileContent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space key was pressed");
            text.text = "buenas";
        }
    }


    void buenas()
    {

    }
}
