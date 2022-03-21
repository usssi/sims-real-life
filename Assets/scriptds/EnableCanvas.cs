using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCanvas : MonoBehaviour
{

    public GameObject EnableThiscanvasButton;
    public GameObject EnableFondoActivo;
    public GameObject DisableThis1;
    public GameObject DisableThis2;
    public GameObject DisableThis3;

    // Start is called before the first frame update
    void Start()
    {
        EnableThiscanvasButton.SetActive(false);
        EnableFondoActivo.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WhenButtonClicked()
    {
        if (EnableThiscanvasButton.activeInHierarchy == true) 
        {
            EnableThiscanvasButton.SetActive(false);
            EnableFondoActivo.SetActive(false);
        }
        else
        {
            EnableThiscanvasButton.SetActive(true);
            EnableFondoActivo.SetActive(true);

        }

        DisableThis1.SetActive(false);
        DisableThis2.SetActive(false);
        DisableThis3.SetActive(false);

    }
}
