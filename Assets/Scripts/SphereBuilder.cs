using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBuilder : MonoBehaviour {

	[SerializeField] GameObject cube;

    void Start()
	{
        //BuildCube();
        //BuildSphere();

        BuildLevel();
	}

    private void BuildLevel()
    {
        int [,,]level = Levels.GetLevel(0);

        int xLen = level.GetLength(0);
        int yLen = level.GetLength(1);
        int zLen = level.GetLength(2);


        for (int i = 0; i < xLen; i++)
        {
            for (int j = 0; j < yLen; j++)
            {
                for (int k = 0; k < zLen; k++)
                {
                    if(level[i,j,k] > 0)
					{
                        GameObject freshGameObj = Instantiate(cube, new Vector3(i, j, k), Quaternion.identity);
						freshGameObj.transform.parent = gameObject.transform;
					}
                }
            }
        }
    }

    void BuildCube()
    {
        int radius = 5;

        for (int i = -radius; i < radius; i++)
        {
            for (int j = -radius; j < radius; j++)
            {
                for (int k = -radius; k < radius; k++)
                {
                    GameObject freshGameObj = Instantiate(cube, new Vector3(i, j + 5, k), Quaternion.identity);
                    freshGameObj.transform.parent = gameObject.transform;
                }
            }
        }
    }

    void BuildSphere()
    {
        int radius = 5;
        Vector3 center = Vector3.zero;

        for (int i = -radius; i < radius; i++)
        {
            for (int j = -radius; j < radius; j++)
            {
                for (int k = -radius; k < radius; k++)
                {
                    Vector3 position = new Vector3(i, j, k);
                    float distance = Vector3.Distance(position, center);
                    if(distance < radius)
                    {
                        GameObject freshGameObj = Instantiate(cube, new Vector3(i, j, k), Quaternion.identity);
                        freshGameObj.transform.parent = gameObject.transform;
                    }
                }
            }
        }
    }
}
