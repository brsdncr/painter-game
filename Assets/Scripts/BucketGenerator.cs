using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BucketGenerator : MonoBehaviour {

    //float timePassed = 0f;
    float timeToPassToGenerateNewCube;
    float firstWaitingTimeToGenerateCube;


    [SerializeField] GameObject bucketPrefab;
    [SerializeField] Camera mainCamera;
    int distance = 4;

    GameObject buckets;

    // Use this for initialization
    void Start()
    {
        SetBuilderVariables();

        InvokeRepeating("CreateNewBucket", firstWaitingTimeToGenerateCube, timeToPassToGenerateNewCube);
    }

    private void Update()
    {
        TrackCamera();
    }

    private void TrackCamera()
    {
        if (mainCamera != null)
        {
            gameObject.transform.position = mainCamera.transform.position + mainCamera.transform.forward * distance;
            gameObject.transform.rotation = new Quaternion(0.0f, mainCamera.transform.rotation.y, 0.0f, mainCamera.transform.rotation.w);
        }
    }

    private void SetBuilderVariables()
    {
        timeToPassToGenerateNewCube = Random.Range(4f, 8f);
        firstWaitingTimeToGenerateCube = Random.Range(2f, 8f);
    }

    private void CreateNewBucket()
    {
        GameObject newBucket = Instantiate(bucketPrefab, transform.position + new Vector3(0f, 5f, 0f), Quaternion.identity) as GameObject;
        
		float leftRightPerc = Random.Range(0f,1f);

		float xDev = 0f;
		if (leftRightPerc <= 0.5)
		{
			xDev = Random.Range(-1f, -0.5f);
		}
		else
		{
			xDev = Random.Range(0.5f, 1f);
		}

		Vector3 moveLeftOrRight = new Vector3(xDev, 0, 0);
		newBucket.transform.position += moveLeftOrRight;
		//newBucket.transform.position = new Vector3(xDev, newBucket.transform.position.y, newBucket.transform.position.z);
		newBucket.transform.parent = gameObject.transform;
    }
}
