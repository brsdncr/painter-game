using System;
using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{
    int rotationSpeed = 40;

    void Update()
    {
        CheckRightKey();
        CheckLeftKey();
        CheckUpKey();
        CheckDownKey();
    }

    private void CheckDownKey()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(1f, 0f, 0f), Time.deltaTime * -rotationSpeed);
        }
    }

    private void CheckUpKey()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(1f, 0f, 0f), Time.deltaTime * rotationSpeed);
        }
    }

    private void CheckLeftKey()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f), Time.deltaTime * -rotationSpeed);
        }
    }

    private void CheckRightKey()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f), Time.deltaTime * rotationSpeed);
        }
    }
}