using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Follow : MonoBehaviour
{
    public Transform target; // Referencja do transformacji gracza
    public float distance = 5.0f; // Odleg³oœæ kamery od gracza
    public float height = 2.0f; // Wysokoœæ kamery wzglêdem gracza
    public float rotationSpeed = 3.0f; // Szybkoœæ obracania kamery
    public float LookUp;
    private float currentRotation = 0.0f;

    void LateUpdate()
    {
        if (target != null)
        {
            // Pobierz aktualn¹ pozycjê myszy
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;

            // Obróæ kamerê wokó³ gracza na podstawie ruchu myszy
            currentRotation += mouseX;
            Quaternion rotation = Quaternion.Euler(0, currentRotation, 0);

            // Oblicz pozycjê i rotacjê kamery na podstawie po³o¿enia gracza, odleg³oœci i wysokoœci
            Vector3 cameraPosition = target.position - (rotation * Vector3.forward * distance);
            cameraPosition.y = target.position.y + height;

            // Ustaw pozycjê i rotacjê kamery
            transform.position = cameraPosition;
            transform.LookAt(target);
            transform.Rotate(-LookUp,0,0);
        }
    }
}
