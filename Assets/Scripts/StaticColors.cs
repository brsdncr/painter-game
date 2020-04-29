using UnityEngine;
using System.Collections;

public static class StaticColors {

    static string[] bucketColors = {
        "ca054d", //Pictorial Carmine
        "3b1c32", //Dark Purple
        "7fb285", //Dark Sea Green
        "ffcf9c", //Peach-Orange
        "b96d40" //Copper
    };

    public static string GetRandomColor()
    {
        return bucketColors[Random.Range(0, bucketColors.Length)];
    }

}
