using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class creditScroller : MonoBehaviour
{
    public TextMeshProUGUI creditsText;
    public float scrollSpeed = 30f;
    public float endPositionY = 781f;
    private RectTransform rectTransform;
    public MenuManager menuManager;
    void Start()
    {
        rectTransform = creditsText.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
        Debug.Log(rectTransform.anchoredPosition.y);
        if (rectTransform.anchoredPosition.y >= endPositionY)
        {
            menuManager.Restart();
        }
    }
}
