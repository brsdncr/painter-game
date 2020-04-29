using System;
using UnityEngine;

public class ColorChanger : MonoBehaviour {


    public void ChangeColor(string hexColor)
    {
        Color unityColor;

        hexColor = "#" + hexColor;

        if (ColorUtility.TryParseHtmlString(hexColor, out unityColor))
        {
            var cubeRenderer = gameObject.GetComponent<Renderer>();
            cubeRenderer.material.SetColor("_Color", unityColor);
        }
        else
        {
            gameObject.GetComponent<Material>().color = Color.white;
        }

    }
}
