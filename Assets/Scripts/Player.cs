using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    string playerColor = "";

    public void SetColor(String color)
    {
        //Debug.Log("Set player to: " + color);
        this.playerColor = color;
    }

    public string GetColor()
    {
        //Debug.Log("Get player color: " + playerColor);
        return this.playerColor;
    }
}
