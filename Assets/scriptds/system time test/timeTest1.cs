using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeTest1 : MonoBehaviour
{
    private int horas;
    private int minutos;
    private int segundos;
    private int currentTime;

    private int savedTime;

    [HideInInspector] public int timeElapsed;
    [HideInInspector] public float timeElapsedFloat;

    private void Awake()
    {
        horas = System.DateTime.Now.Hour * 60 * 60;
        minutos = System.DateTime.Now.Minute * 60;
        segundos = System.DateTime.Now.Second;

        currentTime = horas + minutos + segundos;

        if (PlayerPrefs.GetInt("savedTime")> currentTime)
        {
            timeElapsed = PlayerPrefs.GetInt("savedTime") - currentTime;
        }
        else if (PlayerPrefs.GetInt("savedTime") < currentTime)
        {
            timeElapsed = currentTime - PlayerPrefs.GetInt("savedTime");
        }

        timeElapsedFloat = (float)timeElapsed;

        Debug.Log("open time this session = " + currentTime);
        Debug.Log("time elapsed " + timeElapsed);



    }

    private void OnDestroy()
    {
        horas = System.DateTime.Now.Hour * 60 * 60;
        minutos = System.DateTime.Now.Minute * 60;
        segundos = System.DateTime.Now.Second;

        currentTime = horas + minutos + segundos;

        savedTime = currentTime;

        PlayerPrefs.SetInt("savedTime", savedTime);

        Debug.Log("close time this session = " + PlayerPrefs.GetInt("savedTime"));

    }
}
