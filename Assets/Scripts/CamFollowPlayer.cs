using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject target;

    //Valuses of the postion of the camera needed to be added to the player postion on start
    [SerializeField] Vector3 camOffSet;
    [SerializeField] float size = 2;                                       // usually hight of object so that camera views at the head an not the object's feet
    [HideInInspector] public float currentZoom = 10;                       // The current zoom value
    [HideInInspector] public float zoomSpeed = 4;
    [HideInInspector] public float zoomMin = 5;
    [HideInInspector] public float zoomMax = 15;

    // To rotate camera around the player
    [HideInInspector] public float rotateSpeed = 100;
    [HideInInspector] public float currentRotate = 0;


    private void Update()
    {
        //To zoom in and out when mouse wheel is scrolled
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, zoomMin, zoomMax);

        //To rotate camerara with A & D
        currentRotate -= Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;

    }



    // Updating the positon of camera to follow the player at all times
    void LateUpdate()
    {
        Vector3 requiredSpot = target.transform.position + camOffSet * currentZoom;
        transform.position = requiredSpot + Vector3.up * 2;
        transform.LookAt(target.transform);

        // To rotate camera around the object
        transform.RotateAround(target.transform.position, Vector3.up, currentRotate);
    }
}
