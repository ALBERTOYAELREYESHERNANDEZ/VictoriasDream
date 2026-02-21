using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
      
public class Jefe : MonoBehaviour
{
    //Vida
    private float vidaInicial = 100f;
    private float vidaActual;
    public Image vidaJefe;

    //Danio al jugador
    private float danio = 1f;
    public float danioAJugador;
    public int tipoDanio;

    //Animaciones
    //1-Parado
    //2-Movimiento de brazos (para llamar a los enemigos)
    //3-Movimiento de golpe (Opcional, para cuando esté cerca Victoria)

    public void Start()
    {
        this.vidaActual = this.vidaInicial;
    }

   public void Update()
   {
        this.revisarVida();
   }

    public void revisarVida()
    {
        if (vidaInicial <= 0)
        {
            Debug.Log("JEFE MUERTO");
            LevelLoader.LoadLevel("END");
            Destroy(this.gameObject);
           this.DestruirObjetosEnemigos();
        }
        vidaJefe.fillAmount = vidaInicial / vidaActual;
    }

    public void DanioRecibido(float danioMunicion)
    {
        vidaInicial -= danioMunicion;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            this.danioAJugador = danio;
            this.tipoDanio = 1;
            GameObject.FindObjectOfType<MovimientoJugador>().DanioRecibido(this.danioAJugador, this.tipoDanio);
            Debug.Log("Perdiste x2");

            //3-ANIMACION Movimiento de golpe (Opcional, para cuando esté cerca Victoria) - SE LE PUEDE HACER MAS GRANDE EL COLLIDER PARA QUE ESTE DETECTE A VICTORIA
        }
    }

    public void DestruirObjetosEnemigos()
    {
        GameObject creadorEnemigo = GameObject.Find("CreadorEnemigo");
        Destroy(creadorEnemigo);

        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo");
        foreach (GameObject enemigo in enemigos)
        {
            Destroy(enemigo);
        }
    }
}
