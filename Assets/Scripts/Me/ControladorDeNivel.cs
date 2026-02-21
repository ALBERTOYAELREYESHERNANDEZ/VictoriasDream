using UnityEngine;
public class ControladorDeNivel : MonoBehaviour
{
    public int CantidadActualRecolectables;
    public int bandera = 1;
    public int color;

    private void Start()
    {
        // se incializa la variable 
        this.CantidadActualRecolectables = 0;
        Debug.Log("Cantidad actual: " + this.CantidadActualRecolectables);

        // se invoca un game object de tipo controlador, de ahi el script y el metodo actualizar interfaz, y por ultimo los valores que el otro metodo del otro script recibe
        GameObject.FindObjectOfType<ControladorUI>().ActualizarInterfaz(this.CantidadActualRecolectables, this.bandera);
    }

    public void Update()
    {
        //dependiendo de cual es el valor de la bandera este cambia de color el texto en el canvas
        if (CantidadActualRecolectables == 0)
        {
            this.color = 0;
            GameObject.FindObjectOfType<ControladorUI>().ActualizarColor(this.color);
        }
        else
        {
            this.color = 1;
            GameObject.FindObjectOfType<ControladorUI>().ActualizarColor(this.color);
        }
    }

    public void RegistrarColeccion(int RegistrarColeccion)
    {
        



          //dependiendo de cual es el valor de la bandera este aumenta o dsiminuye la cantidad en el canvas
          if (RegistrarColeccion == 0)
          {
              this.CantidadActualRecolectables--;
              this.bandera = 0;
              GameObject.FindObjectOfType<ControladorUI>().ActualizarInterfaz(this.CantidadActualRecolectables, this.bandera);
          }
          else
          {
              this.CantidadActualRecolectables+=2;
              this.bandera = 1;
              GameObject.FindObjectOfType<ControladorUI>().ActualizarInterfaz(this.CantidadActualRecolectables, this.bandera);
          }
    }
}
