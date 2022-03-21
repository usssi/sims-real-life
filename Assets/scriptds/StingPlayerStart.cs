using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StingPlayerStart : MonoBehaviour
{
    public GameObject zzzControler;
    public GameObject cleanControler;
    public GameObject sedControler;
    public GameObject comidaControler;

    private int currentSleep;
    private int currentClean;
    private int currentSed;
    private int currentHambre;

    private int lowestNeed;

    void Start()
    {
        //invoca el sonido de need dependiendo del valor de lowest need, con un delay de 4 segundos
        Invoke("StingPlay", 4.5f);
        
    }

    void StingPlay()
    {
        //toma el valor de cada barra y la asigna a una variable
        currentSleep = zzzControler.GetComponent<player>().currentZzz;
        currentClean = cleanControler.GetComponent<cleanController>().currentZzz;
        currentSed = sedControler.GetComponent<sedcontroller>().currentZzz;
        currentHambre = comidaControler.GetComponent<comidacontroler>().currentZzz;

        //declara el array y pone las variables dentro
        int[] needsArray = { currentSleep, currentClean, currentSed, currentHambre };

        //esto no se que es pero es para sacar el valor minimo
        int min = needsArray[0];

        //loop for para sacar el valor minimo
        for (int i = 0; i < needsArray.Length; i++)
        {
            if (needsArray[i] < min)
            {
                min = needsArray[i];
            }
        }
        //valor minimo igual lowestneed para usar el valor MIN fuera del loop for
        lowestNeed = min;

        //Debug.Log(lowestNeed + " lowest need");

        if (lowestNeed < 43200)
        {
            if (lowestNeed > 25920)
            {
                FindObjectOfType<audioManager>().Play("need_yellow");
            }
        }
        if (lowestNeed < 25920)
        {
            if (lowestNeed > 12960)
            {
                FindObjectOfType<audioManager>().Play("need_orange");
            }
        }
        if (lowestNeed < 12960)
        {
            if (lowestNeed > 4320)
            {
                FindObjectOfType<audioManager>().Play("need_red");
            }
        }
        if (lowestNeed < 4320)
        {
            if (lowestNeed > 0)
            {
                FindObjectOfType<audioManager>().Play("need_black");
            }
        }
    }

}
