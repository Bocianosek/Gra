using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Follow : MonoBehaviour
{
    public Transform target; // Referencja do transformacji gracza
    public float distance = 5.0f; // Odleg�o�� kamery od gracza
    public float height = 2.0f; // Wysoko�� kamery wzgl�dem gracza
    public float rotationSpeed = 3.0f; // Szybko�� obracania kamery
    public float LookUp;
    private float currentRotation = 0.0f;

    void LateUpdate()
    {
        if (target != null)
        {
            // Pobierz aktualn� pozycj� myszy
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;

            // Obr�� kamer� wok� gracza na podstawie ruchu myszy
            currentRotation += mouseX;
            Quaternion rotation = Quaternion.Euler(0, currentRotation, 0);

            // Oblicz pozycj� i rotacj� kamery na podstawie po�o�enia gracza, odleg�o�ci i wysoko�ci
            Vector3 cameraPosition = target.position - (rotation * Vector3.forward * distance);
            cameraPosition.y = target.position.y + height;

            // Ustaw pozycj� i rotacj� kamery
            transform.position = cameraPosition;
            transform.LookAt(target);
            transform.Rotate(-LookUp,0,0);
        }
    }
}
