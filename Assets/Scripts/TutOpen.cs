using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.ThirdPerson;

public class TutOpen : MonoBehaviour
{
    public ThirdPersonCharacter player;
    public GameObject panelTuto;
    public GameObject panelTuto2;
    public bool jugadorCerca;
    public bool aceptarMision;
    public GameObject[] objetivos;
   
    public GameObject botonDeMision;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonCharacter>();
        panelTuto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && aceptarMision == false)
        {
            Vector3 posicionJugador = new Vector3(transform.position.x, player.gameObject.transform.position.y, transform.position.z);
    player.gameObject.transform.LookAt(posicionJugador);

            //jugador.anim.SetFloat("VelX", 0);
            //jugador.anim.SetFloat("VelY", 0);
            player.enabled = false;
            panelTuto.SetActive(false);
            panelTuto2.SetActive(true);
            //panelNPCMision.SetActive(true);


        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           
            if (aceptarMision == false)
            {
                panelTuto.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
            panelTuto.SetActive(false);
            panelTuto2.SetActive(false);
        }
    }

    public void No()
    {
        player.enabled = true;
        panelTuto.SetActive(false);
        panelTuto2.SetActive(true);

    }

    public void Si()
    {
        player.enabled = true;
        aceptarMision = true;
        for (int i = 0; i < objetivos.Length; i++)
        {
            objetivos[i].SetActive(true);
        }
        

        panelTuto.SetActive(false);
        panelTuto2.SetActive(false);
    }

}
