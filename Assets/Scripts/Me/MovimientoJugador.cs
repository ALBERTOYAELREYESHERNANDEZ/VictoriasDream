using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoJugador : MonoBehaviour
{
    //Registrar la coleccion 
    int RegistraColeccion;
    int Cantidaddulces = 0;

    /*Varibles disparo*/
    public Transform referencia; //puntoDeSalida
    
    //contador y mira
    [SerializeField] private GameObject[] dulces;
    public GameObject Refmira;

    //Personaje
    Transform trPersonaje;
    //Rigidbody rbPersonaje;
   // private float velocidadCaminar = 200f;

    //Camara
    public Transform ejeCamara; //eje
    public Transform prCamara; //posicion y rotacion
    private Transform cam;

    private float rotY = 0f;
    private float velocidadRotacion = 100;
    private float minAgulo = -45;
    private float maxAngulo = 20;
    private float velocidadCamara = 100;

    //Vida
    private float vidaInicial = 50f;
    private float vidaActual;
    public Image vidaJugador;

    //Animaciones
    //1-Animacion de lanzar algo cuando se hace click izquierdo (metodo Lanzar)

    private void Start()
    {
        trPersonaje = this.transform;
        //rbPersonaje = GetComponent<Rigidbody>();

        cam = Camera.main.transform;

        this.Mira();
        this.vidaActual = this.vidaInicial;

    }

    void Update()
    {
        this.ControlCamara();
       //this.ControlMovimiento();
        this.Lanzar();
        this.ActivarMira();
        this.barraVida();
        this.MostrarCursor();
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

    /*
    public void ControlMovimiento()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        float deltaT = Time.deltaTime;

        Vector3 side = velocidadCaminar * deltaX * deltaT * trPersonaje.right;
        Vector3 forward = velocidadCaminar * deltaZ * deltaT * trPersonaje.forward;

        Vector3 direccion = side + forward;
        rbPersonaje.velocity = direccion;
    }
    */

    private void OnTriggerEnter(Collider target)
    {
        if (target.tag == "Recolectable")
        {
            Cantidaddulces +=2;
        }
    }

    private void Lanzar()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //AQUI SE PODRIA LLAMAR LA ANIMACION DE LANZAR

            if (Cantidaddulces == 0)
            {
                Debug.Log("Ya no hay");
            }
            else
            {
                Cantidaddulces--;
                Debug.Log("Quedan " + Cantidaddulces);
                this.RegistraColeccion = 0;
                GameObject.FindObjectOfType<ControladorDeNivel>().RegistrarColeccion(this.RegistraColeccion);
                //envia mensaje al controlador de nivel
                this.CrearDulce();
            }
        }
    }

    private void MostrarCursor()
    {
        Cursor.lockState = (Input.GetKey(KeyCode.F1) ? CursorLockMode.None : CursorLockMode.Locked);
    }

   private void CrearDulce()
    {
        int indiceAleatorio = Random.Range(0, this.dulces.Length);
        GameObject itemNuevo = Instantiate(this.dulces[indiceAleatorio]);
        itemNuevo.transform.position = referencia.position;
        itemNuevo.transform.rotation = referencia.rotation;
        //crea el dulce y toma la referencia para su posicion
   }

    
    public void Mira()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit))
        {
            referencia.LookAt(hit.point);
        }
        else
        {
            Vector3 end = cam.position + cam.forward;
            referencia.LookAt(end);
        }
    }
    
    private void ActivarMira()
    {
        //Activar y desactivar mira
        if (Cantidaddulces >= 1)
        {
            Refmira.SetActive(true);
        }
        else
        {
            Refmira.SetActive(false);
        }
    }

    private void barraVida()
    {
        if (vidaInicial <= 0)
        {
            Debug.Log("PERDISTEEEEEE");
            LevelLoader.LoadLevel("Jefe");
            //Destroy(this.gameObject);

            //Aqui se puede llamar la pantalla de GAME OVER justo depues de destruir el objeto
        }
        vidaJugador.fillAmount = vidaInicial / vidaActual;
    }

    public void DanioRecibido(float danioEnemigo, int tipoDanio)
    {
       if(tipoDanio == 0)
       {
            vidaInicial -= danioEnemigo;
       }
       else
       {
            vidaInicial -= danioEnemigo;
       }
    }
}
