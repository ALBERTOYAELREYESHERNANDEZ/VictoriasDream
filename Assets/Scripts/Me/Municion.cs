using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municion : MonoBehaviour
{
    private float fuerza = 50f;
    private float tiempoDeVida = 2f;
    float deltatime = 0f;

    Rigidbody rb;

    public float danio = 20.0f;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity = this.transform.forward * fuerza;
    }

    private void FixedUpdate()
    {
        deltatime += Time.deltaTime;
        {
            if (deltatime >= tiempoDeVida)
            {
                Destroy(this.gameObject);
            }
        }
    }


    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Jefe")
        {
            GameObject.FindObjectOfType<Jefe>().DanioRecibido(this.danio);
            Debug.Log("Disparo a jefe");
        }
        if (target.tag == "Enemigo")
        {
            GameObject.FindObjectOfType<Enemigo>().danioRecibido(this.danio);
            Debug.Log("Disparo a enemigo");
        }
    }
}