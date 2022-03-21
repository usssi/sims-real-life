using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectHourChangeButton : MonoBehaviour
{
    private int currentTime;

    public GameObject desayuno;
    public GameObject merienda;
    public GameObject almuerzo;
    public GameObject cena;

    private void Start()
    {
        
    }
    void Update()
    {
        currentTime = System.DateTime.Now.Hour * 60 * 60 + System.DateTime.Now.Minute * 60 + System.DateTime.Now.Second;

        if (currentTime>5000)
        {
            if (currentTime< 54000)
            {
                desayuno.SetActive(true);
                almuerzo.SetActive(true);
                merienda.SetActive(false);
                cena.SetActive(false);
            }
            else
            {
                desayuno.SetActive(false);
                almuerzo.SetActive(false);
            }
        }

        if (currentTime>54000)
        {
            if (currentTime<86400)
            {
                merienda.SetActive(true);
                cena.SetActive(true);
            }
        }

        if (currentTime>0)
        {
            if (currentTime<5000)
            {
                merienda.SetActive(true);
                cena.SetActive(true);
            }
        }

    }
}
