using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;



public class Follow : MonoBehaviour
{
    public Transform target; // Referencja do transformacji gracza
    public float distance = 5.0f; // Odleg³oœæ kamery od gracza
    public float height = 2.0f; // Wysokoœæ kamery wzglêdem gracza
    public float rotationSpeed = 3.0f; // Szybkoœæ obracania kamery
    public float LookUpLimit = 90.0f; // Ograniczenie ruchu kamery w górê
    public float LookDownLimit = -90.0f; // Ograniczenie ruchu kamery w dó³
    private float currentRotation = 0.0f;
    private float currentLookUp = 0.0f;

    void LateUpdate()
    {
        if (target != null)
        {
            // Pobierz aktualn¹ pozycjê myszy
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            // Obróæ kamerê wokó³ gracza na podstawie ruchu myszy
            currentRotation += mouseX;
            currentLookUp -= mouseY; // U¿ywamy minusa, aby odwróciæ kierunek ruchu kamery

            // Ogranicz ruch kamery w pionie
            currentLookUp = Mathf.Clamp(currentLookUp, LookDownLimit, LookUpLimit);
            currentLookUp = Mathf.Clamp(currentLookUp, -LookUpLimit, -LookDownLimit);

            // Oblicz pozycjê kamery na podstawie po³o¿enia gracza, odleg³oœci i wysokoœci
            Quaternion rotation = Quaternion.Euler(0, currentRotation, 0);
            Quaternion lookUpRotation = Quaternion.Euler( currentLookUp,0, 0);
            Vector3 cameraPosition = target.position - (rotation * lookUpRotation * Vector3.forward * distance);
            
            cameraPosition.y = target.position.y + height;

            // Ustaw pozycjê i rotacjê kamery
            transform.position = cameraPosition;
            transform.LookAt(target);
        }


        /*private float currentRotation = 0.0f;
        private float currentRotatio = 0.0f;

        void LateUpdate()
        {
            if (target != null)
            {
                // Pobierz aktualn¹ pozycjê myszy
                float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
                float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

                // Obróæ kamerê wokó³ gracza na podstawie ruchu myszy
                currentRotation += mouseX;
                Quaternion rotation = Quaternion.Euler(0, currentRotation, 0);

                currentRotation += mouseY;
                Quaternion rotatio = Quaternion.Euler(0, currentRotatio, 0);

                // Oblicz pozycjê i rotacjê kamery na podstawie po³o¿enia gracza, odleg³oœci i wysokoœci
                Vector3 cameraPosition = target.position - (rotation * Vector3.forward * distance);
                Vector3 cameraPositio = target.position + (rotatio * Vector3.forward * distance);
                cameraPosition.y = target.position.y + height;

                // Ustaw pozycjê i rotacjê kamery
                transform.position = cameraPosition;
                transform.LookAt(target);
                transform.Rotate(-LookUp,0,0);
            }*/
    }

    /*[Header("Reference Fields")]
    public LayerMask camRaycastMask;
    public CharacterController controller;
    public Transform cameraTransform;
    public Transform cameraPivot;
    [Header("Numeric Fields")]
    public float controllerLookSmoothTime;
    public float LookSmoothTime;
    public float cameraDistance;
    [Space]
    public Vector3 pivotOffset;
    public Vector2 xRotationLimits;
    public float gravity;
    public float sensitivity;
    public float moveSpeed;
    // Used on the Player Gameobject with the character controller to smooth rotating
    private float yVelocity;
    private float yAngleOffset;
    private float currentControllerYRotation;
    private float targetControllerYRotation;
    private float controllerYRotationVelocity;
    // Used on the Player Camera to smooth rotating
    private float currentCameraXRotation;
    private float currentCameraYRotation;
    private float xRotationVelocity;
    private float yRotationVelocity;
    private float targetYRotation;
    private float targetXRotation;

    void Update()
    {
        
        setCameraLook();
        setControllerLook();
    }



    void setControllerLook() {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
            if (xInput * xInput + yInput * yInput > 0) { 
            targetControllerYRotation = Mathf.Atan2(xInput, yInput) * Mathf.Rad2Deg;
            targetControllerYRotation -= yAngleOffset;
        }
        currentControllerYRotation = Mathf.SmoothDampAngle(currentControllerYRotation, targetControllerYRotation, ref controllerYRotationVelocity, controllerLookSmoothTime);
        controller.transform.eulerAngles = new Vector3(0f, currentControllerYRotation, 0f);
    }

    void setCameraLook()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            targetYRotation += mouseX * sensitivity;
            targetXRotation -= mouseY * sensitivity;
            targetXRotation = Mathf.Clamp(targetXRotation, xRotationLimits.x, xRotationLimits.y);
        }

        currentCameraXRotation = Mathf.SmoothDampAngle(currentCameraXRotation, targetXRotation, ref xRotationVelocity, LookSmoothTime);
        currentCameraYRotation = Mathf.SmoothDampAngle(currentCameraYRotation, targetYRotation, ref yRotationVelocity, LookSmoothTime);
        cameraPivot.eulerAngles = new Vector3(currentCameraXRotation, currentCameraYRotation, 0f);

        Ray camRay = new Ray(cameraPivot.position, -cameraPivot.forward);
        float maxDistance = cameraDistance;
        if (Physics.SphereCast(camRay, 0.25f, out RaycastHit hitInfo, cameraDistance, camRaycastMask))
        {
            maxDistance = (hitInfo.point - cameraPivot.position).magnitude - 0.25f;
        }

        cameraTransform.localPosition = Vector3.forward * -(maxDistance - 0.1f);
        yAngleOffset = Mathf.Atan2(cameraPivot.forward.z, cameraPivot.forward.x) * Mathf.Rad2Deg - 90f;




    }*/

}
