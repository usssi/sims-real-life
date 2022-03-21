using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonAjustes : MonoBehaviour
{
    public GameObject botonRestart;
    public GameObject EnableFondoActivo;



    private void Start()
    {
        botonRestart.SetActive(false);
    }
    public void Ajustes()
    {
        if (botonRestart.activeInHierarchy == true)
        {
            botonRestart.SetActive(false);
            EnableFondoActivo.SetActive(false);

        }
        else
        {
            botonRestart.SetActive(true);
            EnableFondoActivo.SetActive(true);

        }

        FindObjectOfType<audioManager>().Play("ajustes");




    }


    public void Restart()
    {
        FindObjectOfType<audioManager>().Play("restart");

        botonRestart.SetActive(false);
        EnableFondoActivo.SetActive(false);


    }
}
