using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorItems : MonoBehaviour
{
    public GameObject[] ItemDulce;
    private int cantidadDulces = 16;


    //Delimitadores
    private float rangoMinimoX = -10f;
    private float rangoMaximoX = 5f;

    //De preferencia NO TOCAR
    private float rangoMinimoY = 0.6f;
    private float rangoMaximoY = 0.6f;
    //De preferencia NO TOCAR

    private float rangoMinimoZ = -2f;
    private float rangoMaximoZ = 8f;


    //tiempo para siguientes items
    private float tiempo = 35.0f;

    void Start()
    {
        for (int i = 0; i < cantidadDulces; i++)
        {
            int indiceAleatorio = Random.Range(0, ItemDulce.Length);
            //GameObject itemNuevo = Instantiate(ItemDulce[indiceAleatorio]);
            //itemNuevo.transform.position = new Vector3(i, 1, 0);
            Vector3 posicionAleatorioa = new Vector3(Random.Range(rangoMinimoX, rangoMaximoX), Random.Range(rangoMinimoY, rangoMaximoY), Random.Range(rangoMinimoZ, rangoMaximoZ));
            GameObject itemNuevo = Instantiate(ItemDulce[indiceAleatorio], posicionAleatorioa, Quaternion.identity);


            //accede al rigibody del item y lo desactiva
            Rigidbody rb = itemNuevo.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.isKinematic = true;
            }
            //accede al rigibody del item y lo desactiva

            Destroy(itemNuevo, 15f);
        }

        InvokeRepeating("SpawItem", tiempo, tiempo);
    }
    
    private void SpawItem()
    {
        for (int i = 0; i < cantidadDulces; i++)
        {
            int indiceAleatorio = Random.Range(0, ItemDulce.Length);
            Vector3 posicionAleatorioa = new Vector3(Random.Range(rangoMinimoX, rangoMaximoX), Random.Range(rangoMinimoY, rangoMaximoY), Random.Range(rangoMinimoZ, rangoMaximoZ));
            GameObject itemNuevo = Instantiate(ItemDulce[indiceAleatorio], posicionAleatorioa, Quaternion.identity);

            //acceder al rigibody del item y lo desactiva
            Rigidbody rb = itemNuevo.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
            //acceder al rigibody del item y lo desactiva

            Destroy(itemNuevo, 15f);
        }
    }
    
}
