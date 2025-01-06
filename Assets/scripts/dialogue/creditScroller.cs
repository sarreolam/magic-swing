using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// Controla el desplazamiento de los créditos en pantalla.
public class creditScroller : MonoBehaviour
{
    public TextMeshProUGUI creditsText;
    public float scrollSpeed = 30f;
    public float endPositionY = 781f;
    private RectTransform rectTransform;
    public MenuManager menuManager;

    /// Inicializa las referencias necesarias.
    void Start()
    {
        rectTransform = creditsText.GetComponent<RectTransform>();
    }
    /// Se ejecuta en cada cuadro; desplaza los créditos hacia arriba y reinicia el menú si llegan al final.

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
        if (rectTransform.anchoredPosition.y >= endPositionY)
        {
            menuManager.Restart();
        }
    }
}
