using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    //perseguir_Objetivo
    //public Transform Objetivo;
    private float velocidad = 1f;
    public NavMeshAgent IA;

    //Animacion
    //1-Correr
    //2-Pegar o golpear cuadno este cerca de Vic

    //barra de vida
    private float vidaInicial = 4f;
    private float vidaActual;
    public Image vidaEnemigo;

    //Daño al jugador
    private float danio = 0.03f;
    public float DanioAJugador;
    public int tipoDanio;


    private void Start()
    {
        this.vidaActual = this.vidaInicial;
    }

    public void Update()
    {
        this.SeguirObjetivo();
        this.revisarVida();
    }


    private void SeguirObjetivo()
    {
        GameObject Objetivo = GameObject.FindWithTag("Player");
        Transform posicionObjetivo = Objetivo.transform;

        IA.speed = velocidad;
        //IA.SetDestination(Objetivo.position);
        IA.SetDestination(posicionObjetivo.position);
    }


    public void revisarVida()
    {
        if(vidaInicial <= 0)
        {
            //Debug.Log("Enemigo Abatido");
            Destroy(this.gameObject);
        }
        vidaEnemigo.fillAmount = vidaInicial / vidaActual;
    }


    public void danioRecibido(float danioMunicion)
    {
        vidaInicial -= danioMunicion;
    }
    

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.DanioAJugador = danio;
            this.tipoDanio = 0;
            GameObject.FindObjectOfType<MovimientoJugador>().DanioRecibido(this.DanioAJugador, this.tipoDanio);
            Debug.Log("Golpe a jugador");
        }
    }
    
}
