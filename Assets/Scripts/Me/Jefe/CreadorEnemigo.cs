using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorEnemigo : MonoBehaviour
{
    [SerializeField] private GameObject prefabEnemigo;
    [SerializeField] private GameObject puntodeCreacion;


    private float timpoProximoEnemigo = 40.0f;
    private int enemigos = 6;
    private int enemigosIniciales;

    
    private void Start()
    {
        this.CrearEnemigosIniciales();
        InvokeRepeating("SpawEnemigo", timpoProximoEnemigo, timpoProximoEnemigo);
    }

    private void CrearEnemigosIniciales()
    {
        this.enemigosIniciales = 4;
        for (int i = 0; i < enemigosIniciales; i++)
        {
            Instantiate(prefabEnemigo, puntodeCreacion.transform.position, puntodeCreacion.transform.rotation);
        }
    }

    private void SpawEnemigo()
    {
        for (int i = 0; i < enemigos; i++)
        {
            Instantiate(prefabEnemigo, puntodeCreacion.transform.position, puntodeCreacion.transform.rotation);
        }
        this.enemigos += 2;
    }
}
