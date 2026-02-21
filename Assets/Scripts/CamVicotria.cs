using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamVicotria : MonoBehaviour
{
    //Personaje
    Transform trPersonaje;

    //Camara
    public Transform ejeCamara; //eje
    public Transform prCamara; //posicion y rotacion
    private Transform cam;

    private float rotY = 0f;
    private float velocidadRotacion = 100;
    private float minAgulo = -45;
    private float maxAngulo = 10;
    private float velocidadCamara = 100;

    private void Start()
    {
        trPersonaje = this.transform;
        cam = Camera.main.transform;
    }

    void Update()
    {
        this.ControlCamara();
    }

    public void ControlCamara()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaT = Time.deltaTime;

        rotY += mouseY * velocidadRotacion * deltaT;

        float roX = mouseX * velocidadRotacion * deltaT;
        trPersonaje.Rotate(0, roX, 0);

        rotY = Mathf.Clamp(rotY, minAgulo, maxAngulo);

        Quaternion rotacionLocal = Quaternion.Euler(-rotY, 0, 0);
        ejeCamara.localRotation = rotacionLocal;

        cam.position = Vector3.Lerp(cam.position, prCamara.position, velocidadCamara * deltaT);
        cam.rotation = Quaternion.Lerp(cam.rotation, prCamara.rotation, velocidadCamara * deltaT);
    }
}
