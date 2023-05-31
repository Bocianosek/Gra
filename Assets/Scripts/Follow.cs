using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;



public class Follow : MonoBehaviour
{
    public Transform target; 
    public float distance = 5.0f; 
    public float height = 2.0f; 
    public float rotationSpeed = 3.0f; 
    public float LookUpLimit = 90.0f; 
    public float LookDownLimit = -90.0f; 
    private float currentRotation = 0.0f;
    private float currentLookUp = 0.0f;

    void LateUpdate()
    {
        if (target != null)
        {

            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;


            currentRotation += mouseX;
            currentLookUp -= mouseY;


            currentLookUp = Mathf.Clamp(currentLookUp, LookDownLimit, LookUpLimit);
            currentLookUp = Mathf.Clamp(currentLookUp, -LookUpLimit, -LookDownLimit);


            Quaternion rotation = Quaternion.Euler(0, currentRotation, 0);
            Quaternion lookUpRotation = Quaternion.Euler(currentLookUp, 0, 0);
            Vector3 cameraPosition = target.position - (rotation * lookUpRotation * Vector3.forward * distance);

            cameraPosition.y = target.position.y + height;


            transform.position = cameraPosition;
            transform.LookAt(target);
        }


    }

}
