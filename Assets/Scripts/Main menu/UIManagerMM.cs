using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerMM : MonoBehaviour
{
    public GameObject opcionesPanel;


    // Start is called before the first frame update
    void Start()
    {
        opcionesPanel.SetActive(false);
    }

    public void AbrirOpciones(){

        opcionesPanel.SetActive(true);

    }
}
