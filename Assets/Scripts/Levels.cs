using System.Collections.Generic;

public static class Levels {

    //static List<int[,,]> levelArray = new List<int[,,]>();

    static int[, ,] level1 = {
        {
            { 0, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }
        },
        {
            { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }
        },
        {
            { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }
        },
        {
            { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }
        }
    };

public static int[,,] GetLevel(int levelNo)
    {
        return level1;
        /*switch (levelNo)
        {
            case 1:
                
            default:
                break;
        }*/
    }

    


}
