using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject[] paneles;

    private void Awake()
    {
        DesactivarAllPaneles();
        paneles[0].SetActive(true);
    }

    public void ChangePanel(GameObject panel)
    {
        DesactivarAllPaneles();
        panel.SetActive(true);
    }

    public void DesactivarAllPaneles()
    {
        for (int i = 0; i < paneles.Length; i++)
        {
            paneles[i].SetActive(false);
        }
    }
}
