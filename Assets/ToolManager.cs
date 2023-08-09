using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolManager : MonoBehaviour
{
    public static ToolManager instance;
    [SerializeField]
    private int maxTools = 8; // for color grading purposes

    private void Awake()
    {
        instance = this;
    }
    public void SetAvailable(int toolIndex, int amount)
    {
        Color newColor;
        if (amount > 0)
            newColor = Color.white;
        else
            newColor = new Color(1f,1f,1f,.7f);
        foreach (Image spr in transform.GetChild(toolIndex).GetComponentsInChildren<Image>())
        {
            spr.color = newColor;
        }
        if (amount > 1)
        {
            transform.GetChild(toolIndex).GetComponentInChildren<TextMeshProUGUI>().text = "x " + amount;
        }
        else
            transform.GetChild(toolIndex).GetComponentInChildren<TextMeshProUGUI>().text = "";

        float t = (amount - 2) / (maxTools * 2f);
        Color top = Color.HSVToRGB(.5f - t,1,1); // 180 to 0
        Color bottom = Color.HSVToRGB((21/36f) - t, 1, 1); // 210 to 30

        VertexGradient newGradient = new VertexGradient(top, top, bottom, bottom);
        transform.GetChild(toolIndex).GetComponentInChildren<TextMeshProUGUI>().colorGradient
            = newGradient;
    }
}
