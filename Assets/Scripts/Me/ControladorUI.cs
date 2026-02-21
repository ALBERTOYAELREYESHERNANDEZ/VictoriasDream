using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorUI : MonoBehaviour
{
    public void ActualizarInterfaz(int cantidadActualRecolectable, int bandera)
    {
        
        if(bandera == 0)
        {
            GameObject.Find("TextoRecolectables").GetComponent<Text>().text = "" + cantidadActualRecolectable;
        }
        else
        {
            GameObject.Find("TextoRecolectables").GetComponent<Text>().text = "" + cantidadActualRecolectable;
        }
        
    }

    public void ActualizarColor(int color)
    {
        if(color == 0)
        {
            GameObject.Find("TextoRecolectables").GetComponent<Text>().color = Color.red;
        }
        else
        {
            GameObject.Find("TextoRecolectables").GetComponent<Text>().color = Color.white;
        }
    }
}
