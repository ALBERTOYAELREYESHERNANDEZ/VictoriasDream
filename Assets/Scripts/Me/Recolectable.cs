using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolectable : MonoBehaviour
{
    //Bandera para registrar la coleccion 
    int RegistraColeccion;
      void Update()
    {
        //rotacion
        this.transform.Rotate(10f * Time.deltaTime, 10f * Time.deltaTime, 10f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Player")
        {
            this.Recolectar();
        }
        
    }

    private void Recolectar()
    {
        Debug.Log("Colsion detectada");
        this.RegistraColeccion = 1;
        GameObject.FindObjectOfType<ControladorDeNivel>().RegistrarColeccion(this.RegistraColeccion);
        Destroy(this.gameObject);
    }
}

