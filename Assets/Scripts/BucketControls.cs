using System;
using UnityEngine;

public class BucketControls : MonoBehaviour
{

    [SerializeField] Camera dropCam;
	Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    // Update is called once per frame
    void Update()
    {
        CheckPlayerMouseInput();
        CheckPlayerTouchInput();
    }

    private void CheckPlayerMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckBucketCollisionForMouse();
        }
    }

    private void CheckBucketCollisionForMouse()
    {
        Ray ray = dropCam.ScreenPointToRay(Input.mousePosition);
        //Debug.Log(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 1000f))
        {
            string hitObjectTag = hitInfo.transform.tag;
            //Debug.DrawRay(Input.mousePosition);
            if (hitObjectTag.Equals("Bucket"))
            {
                String colorToSet = hitInfo.transform.GetComponent<Bucket>().GetBucketColor();
                player.SetColor(colorToSet);
                Destroy(hitInfo.collider.gameObject);
            }
        }
    }

    private void CheckPlayerTouchInput()
    {
        if (Input.touchCount > 0)
        {
            CheckBucketCollisionForTouch();
        }
    }

    private void CheckBucketCollisionForTouch()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = dropCam.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 100))
            {

                string hitObjectTag = hitInfo.transform.tag;
                if (hitObjectTag.Equals("Bucket"))
                {
                    String colorToSet = hitInfo.transform.GetComponent<Bucket>().GetBucketColor();
                    player.SetColor(colorToSet);
                    //pi.SetPlayerColor(colorToSet);
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
    }
}
