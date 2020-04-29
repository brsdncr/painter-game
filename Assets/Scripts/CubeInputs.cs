using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInputs : MonoBehaviour {

    Vector3 touchPosWorld;
    [SerializeField] GameObject splashPrefab;
    Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update () {

        CheckPlayerInput();

    }

    private void CheckPlayerInput()
    {
        if (Input.touchCount > 0)
        {
            CheckPlayerTouchInput();
        }
        else if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            CheckPlayerMouseInput();
        }
    }

    private void CheckPlayerTouchInput()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            CheckShapeCollision(0);
        }
    }



    private void CheckPlayerMouseInput()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            CheckShapeCollision(1);
        }
    }


    private void CheckShapeCollision(int inputType)
    {

        Vector2 inputPosition;
        /*if (inputType == 0)
        {
            inputPosition = Input.GetTouch(0).position;
        }
        else if (inputType == 1)
        {
            inputPosition = Input.mousePosition;
        }
        else
        {
            return;
        }*/
        inputPosition = Input.mousePosition;

        Ray ray = Camera.main.ScreenPointToRay(inputPosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            Transform hitObject = hitInfo.transform;
            string hitObjectTag = hitObject.tag;
            if (hitObjectTag.Equals("Cube"))
            {
                string playerColor = player.GetColor();
                if (playerColor != "")
                {
                    ColorChanger colorChanger = hitObject.gameObject.GetComponent<ColorChanger>();
                    //ColorChanger colorChanger = hitInfo.transform.GetComponent<ColorChanger>();
                    colorChanger.ChangeColor(playerColor);
                }
            }
        }
    }
}
