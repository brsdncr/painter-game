using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchController : MonoBehaviour {

    int rotationSpeed = 40;
    int screenDividerForTouchWidth = 4;
    int screenDividerForTouchHeight = 6;

    // Update is called once per frame
    [Obsolete]
    void Update () {
        HandleTouch();
	}

    [Obsolete]
    private void HandleTouch()
    {
        if(Input.touchCount > 0)
        {
            if(Input.touchCount == 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                return;
            }

            if(Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                Touch touch = Input.GetTouch(0);

                int dividedAreaWidth = Screen.width / screenDividerForTouchWidth;
                int dividedAreaHeight = Screen.height / screenDividerForTouchHeight;

                if(touch.position.y <= dividedAreaHeight) //rotate only if bottom of the screen touched
                {
                    if (touch.position.x <= dividedAreaWidth)
                    {
                        this.transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f), Time.deltaTime * -rotationSpeed);
                    }
                    else if (touch.position.x >= (screenDividerForTouchWidth - 1) * dividedAreaWidth && (touch.position.x < Screen.width))
                    {
                        this.transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f), Time.deltaTime * rotationSpeed);
                    }
                }
            }
        }
    }
}
